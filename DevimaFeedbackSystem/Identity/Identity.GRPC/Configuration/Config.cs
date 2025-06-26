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
                ClientId = "feedbackClient",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "feedbackScope" }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("feedbackScope")
        };
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("feedbackResource")
            {
                Scopes = { "feedbackScope" }  
            }
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {

        };
    }
}
