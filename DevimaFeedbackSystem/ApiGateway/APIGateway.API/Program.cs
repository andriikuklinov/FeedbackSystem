
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
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

var app = builder.Build();
app.UseCors("CustomPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
