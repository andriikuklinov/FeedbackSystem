using Duende.IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System.Security.Claims;

namespace Identity.GRPC.Configuration
{
    public class Config
    {
        public static IEnumerable<TestUser> TestUsers => new TestUser[]
        {
            new TestUser
            {
                SubjectId="1",
                Username="andrii",
                Password="qwerty",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Name, "Andrii Kuklinov"),
                    new Claim(JwtClaimTypes.Email, "akuklinov@outlook.com")
                }
            }
        };
        public static IEnumerable<Client> Clients => new Client[] 
        {
            new Client
            {
                ClientId = "gatewayClient",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "gatewayScope", "feedbackScope", "moduleScope" }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("feedbackScope"),
            new ApiScope("gatewayScope"),
            new ApiScope("moduleScope"),
        };
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("gatewayResource")
            {
                Scopes = { "gatewayScope", "feedbackScope", "moduleScope" }
                
            }
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {

        };
    }
}
