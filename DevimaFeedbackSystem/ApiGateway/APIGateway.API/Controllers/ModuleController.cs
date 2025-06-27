using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.GRPC.Protos;

namespace APIGateway.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class ModuleController : Controller
    {
        private readonly IConfiguration _configuration;
        public ModuleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<JsonResult> GetModules()
        {
            using var chanel = GrpcChannel.ForAddress(_configuration["Module.Grpc"]);
            var client = new ModuleProtoService.ModuleProtoServiceClient(chanel);
            var headers = new Grpc.Core.Metadata();
            headers.Add("Authorization", $"{HttpContext.Request.Headers.Authorization}");
            var reply = await client.GetModulesAsync(new Google.Protobuf.WellKnownTypes.Empty());

            return Json(reply);
        }
    }
}
