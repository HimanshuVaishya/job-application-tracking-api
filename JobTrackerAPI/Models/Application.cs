namespace JobTrackerAPI.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public string ResumePath { get; set; }
        public string Status { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
