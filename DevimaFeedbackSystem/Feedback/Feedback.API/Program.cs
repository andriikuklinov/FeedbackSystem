using DevimaFeedbackSystem.Common.Core.Exceptions.Handlers;
using DevimaFeedbackSystem.Common.Core.Validation;
using Feedback.API.Data;
using Feedback.API.Data.Repositories;
using Feedback.API.Data.Repositories.Contracts;
using Feedback.API.Feedbacks.Commands.CreateFeedback;
using Feedback.API.MappingProfile;
using Feedback.API.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddDbContext<FeedbackContext>((options) =>
{
    options.UseInMemoryDatabase("FeedbackDb");
});
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ValidationInterceptor>();
});
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new FeedbackMappingProfile());
});
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateFeedbackCommandValidator>();

var app = builder.Build();
app.MapGrpcService<FeedbackService>();

app.Run();
