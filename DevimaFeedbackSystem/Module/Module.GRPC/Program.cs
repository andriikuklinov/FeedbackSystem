using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Module.GRPC.Data;
using Module.GRPC.Data.Repositories;
using Module.GRPC.Data.Repositories.Contracts;
using Module.GRPC.MappingProfile;
using Module.GRPC.Services;
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
builder.Services.AddGrpc();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.MapGrpcService<ModuleService>();

app.Run();
