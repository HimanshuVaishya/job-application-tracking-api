namespace JobTrackerAPI.DTOs
{
    public class ApplyJobDto
    {
        public int JobId { get; set; }
        public IFormFile Resume { get; set; }
    }
}
