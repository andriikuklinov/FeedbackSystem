using DevimaFeedbackSystem.Common.Core.Validation;
using Feedback.API.Data;
using Feedback.API.Data.Repositories;
using Feedback.API.Data.Repositories.Contracts;
using Feedback.API.Feedbacks.Commands.CreateFeedback;
using Feedback.API.MappingProfile;
using Feedback.API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddDbContext<FeedbackContext>((options) =>
{
    options.UseInMemoryDatabase("FeedbackDb");
});
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ValidationInterceptor>();
});
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new FeedbackMappingProfile());
});
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
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
builder.Services.AddValidatorsFromAssemblyContaining<CreateFeedbackCommandValidator>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
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


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5014, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapGrpcService<FeedbackService>();
app.Run();
