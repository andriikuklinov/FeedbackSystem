namespace APIGateway.API.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.UtcNow;
        public int Rating { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
    }
}
