using System.Threading.Tasks;
using Microsoft.Identity.Client;
namespace az204_auth
{
    class Program
    {
        private const string _clientId = "c273045e-9cc9-49c9-9f2a-962841567b81";
        private const string _tenantId = "09ded0c2-b0e9-42c1-9261-a420d41c2b95";
        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

            string[] scopes = { "user.read" };
            
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
            Console.WriteLine($"Token:\t{result.AccessToken}");
        }

    }
}
