using Feedback.API.Data;
using Feedback.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FeedbackContext>((options) =>
{
    options.UseInMemoryDatabase("FeedbackDb");
});
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<FeedbackService>();

app.Run();
