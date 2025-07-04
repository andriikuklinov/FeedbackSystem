﻿using DevimaFeedbackSystem.Common.Core.CQRS;

namespace Feedback.API.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommand: ICommand<CreateFeedbackResult>
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
