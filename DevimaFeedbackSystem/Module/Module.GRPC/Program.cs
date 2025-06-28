using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Module.GRPC.Data;
using Module.GRPC.Data.Repositories;
using Module.GRPC.Data.Repositories.Contracts;
using Module.GRPC.MappingProfile;
using Module.GRPC.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IModuleRespository, ModuleRepository>();
builder.Services.AddDbContext<ModuleContext>((options) =>
{
    options.UseInMemoryDatabase("ModuleDb");
});
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new ModuleMappingProfile());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", policy =>
    {
        policy.WithOrigins(new string[] { "http://api-gateway:5135", "http://localhost" })
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.Authority = "http://identity-server:5000";
        options.Audience = "gatewayResource";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://identity-server:5000",
            ValidAudience = "gatewayResource",
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret"))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddGrpc();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5064, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapGrpcService<ModuleService>();

app.Run();
