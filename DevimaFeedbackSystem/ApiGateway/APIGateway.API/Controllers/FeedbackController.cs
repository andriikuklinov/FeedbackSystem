using Feedback.API.Protos;
using Feedback.API.Protos.Client;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using FeedbackModel = APIGateway.API.Models.Feedback;

namespace APIGateway.API.Controllers
{
    [Route("/[controller]/[action]")]
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IConfiguration _configuration;
        public FeedbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<JsonResult> GetUserFeedbacks(int userId)
        {
            using var chanel = GrpcChannel.ForAddress(_configuration["Feedback.Grpc"]);
            var client = new FeedbackProtoService.FeedbackProtoServiceClient(chanel);
            var headers = new Grpc.Core.Metadata();
            headers.Add("Authorization", $"{HttpContext.Request.Headers.Authorization}");
            var reply = await client.GetFeedbacksByUserIdAsync(new GetFeedbackByUserIdRequest { UserId = userId }, headers);

            return Json(reply.Feedbacks);
        }
        [HttpGet]
        public async Task<JsonResult> GetModuleFeedbacks(int moduleId, string orderByRating = "asc")
        {
            using var chanel = GrpcChannel.ForAddress(_configuration["Feedback.Grpc"]);
            var client = new FeedbackProtoService.FeedbackProtoServiceClient(chanel);
            var headers = new Grpc.Core.Metadata();
            headers.Add("Authorization", $"{HttpContext.Request.Headers.Authorization}");
            var reply = await client.GetFeedbacksByModuleIdAsync(new GetFeedbacksByModuleIdRequest { ModuleId = moduleId, OrderByRating = orderByRating }, headers);

            return Json(reply);
        }

        [HttpPost]
        public async Task<JsonResult> CreateFeedback([FromBody] FeedbackModel feedback)
        {
            using var chanel = GrpcChannel.ForAddress(_configuration["Feedback.Grpc"]);
            var client = new FeedbackProtoService.FeedbackProtoServiceClient(chanel);
            var headers = new Grpc.Core.Metadata();
            headers.Add("Authorization", $"{HttpContext.Request.Headers.Authorization}");
            var reply = await client.CreateFeedbackAsync(new CreateFeedbackRequest
            {
                Feedback = new Feedback.API.Protos.Client.FeedbackModel
                {
                    Id = feedback.Id,
                    Comment = feedback.Comment,
                    ModuleId = feedback.ModuleId,
                    Rating = feedback.Rating,
                    UserId = feedback.UserId
                }
            }, headers);

            return Json(reply);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteFeedback([FromBody] FeedbackModel feedback)
        {
            using var chanel = GrpcChannel.ForAddress(_configuration["Feedback.Grpc"]);
            var client = new FeedbackProtoService.FeedbackProtoServiceClient(chanel);
            var headers = new Grpc.Core.Metadata();
            headers.Add("Authorization", $"{HttpContext.Request.Headers.Authorization}");
            var reply = await client.RemoveFeedbackAsync(new Feedback.API.Protos.Client.FeedbackModel
            {
                Id = feedback.Id,
                Comment = feedback.Comment,
                ModuleId = feedback.ModuleId,
                Rating = feedback.Rating,
                UserId = feedback.UserId
            }, headers);

            return Json(reply);
        }
    }
}
