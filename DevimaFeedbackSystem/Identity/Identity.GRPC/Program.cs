using Identity.GRPC.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityServer(config=>config.AccessTokenJwtType="Bearer")
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddTestUsers(Config.TestUsers.ToList())
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.Run();
