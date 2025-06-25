using DevimaFeedbackSystem.Common.Core.Exceptions.Handlers;
using Feedback.API.Data;
using Feedback.API.Data.Repositories;
using Feedback.API.Data.Repositories.Contracts;
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
builder.Services.AddGrpc();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new FeedbackMappingProfile());
});
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.MapGrpcService<FeedbackService>();

app.Run();
