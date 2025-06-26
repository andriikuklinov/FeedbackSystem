using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

namespace Identity.GRPC.Configuration
{
    public class Config
    {
        //public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        //{
        //    new IdentityResource[]
        //    {
        //         IdentityResources.OpenId(),
        //        new IdentityResources.Profile()
        //    }
        //};
        public static IEnumerable<Client> Clients => new Client[] 
        {
            new Client
            {
                ClientId = "feedbackClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
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
        public static IEnumerable<TestUser> TestUsers => new TestUser[]
        {

        };
    }
}
