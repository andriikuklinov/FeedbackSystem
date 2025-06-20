using Feedback.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FeedbackContext>((options) =>
{
    options.UseInMemoryDatabase("FeedbackDb");
});

var app = builder.Build();



app.Run();
