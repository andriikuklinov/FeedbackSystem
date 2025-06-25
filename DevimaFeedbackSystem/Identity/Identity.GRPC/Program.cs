using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using Identity.GRPC.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestUsers.ToList())
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.Run();
