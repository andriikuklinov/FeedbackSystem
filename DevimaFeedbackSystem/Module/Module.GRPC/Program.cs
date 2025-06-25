using Microsoft.EntityFrameworkCore;
using Module.GRPC.Data;
using Module.GRPC.Data.Repositories;
using Module.GRPC.Data.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IModuleRespository, ModuleRepository>();
builder.Services.AddDbContext<ModuleContext>((options) =>
{
    options.UseInMemoryDatabase("ModuleDb");
});
var app = builder.Build();

app.Run();
