using DevimaFeedbackSystem.Common.Core.DataAccess.Model;

namespace Feedback.API.Data.Entities
{
    public class Feedback : IEntity
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
    }
}
