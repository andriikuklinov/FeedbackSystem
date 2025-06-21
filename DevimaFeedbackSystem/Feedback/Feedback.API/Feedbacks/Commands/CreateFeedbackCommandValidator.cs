using FluentValidation;

namespace Feedback.API.Feedbacks.Commands
{
    public class CreateFeedbackCommandValidator: AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(feedback => feedback.Rating).NotEmpty()
                .WithMessage("Rating is required.")
                .GreaterThan(0)
                .LessThanOrEqualTo(5).WithMessage("Rating should be between 1 and 5.");
            RuleFor(feedback => feedback.ModuleId).NotEmpty()
                .WithMessage("Module is empty.");
            RuleFor(feedback => feedback.UserId).NotEmpty()
                .WithMessage("User is empty.");
        }
    }
}
