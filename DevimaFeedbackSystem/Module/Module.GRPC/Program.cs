using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7258";
        options.Audience = "gatewayResource";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7258",
            ValidAudience = "gatewayResource",
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret"))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddGrpc();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapGrpcService<ModuleService>();

app.Run();
