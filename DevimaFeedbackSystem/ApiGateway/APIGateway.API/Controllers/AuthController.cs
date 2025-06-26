using APIGateway.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIGateway.API.Controllers
{
    [Route("/[controller]/[action]")]
    public class AuthController: Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<JsonResult> Login([FromBody]Credentials credentials)
        {
            var formData = new Dictionary<string, string>()
            {
                { "grant_type", "password" },
                { "scope", "gatewayScope feedbackScope" },
                { "client_id", "gatewayClient" },
                { "client_secret", "secret" },
                { "api_resource", "gatewayResource" },
                { "username", $"{credentials.Login}" },
                { "password", $"{credentials.Password}" }
            };
            var content = new FormUrlEncodedContent(formData);
            content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";

            var response = await _httpClient.PostAsync("https://localhost:7258/connect/token", content);

            return Json(await response.Content.ReadAsStringAsync());
        }
    }
}
