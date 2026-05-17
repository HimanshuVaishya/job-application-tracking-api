using System.ComponentModel.DataAnnotations;

namespace JobTrackerAPI.DTOs
{
    public class CreateJobDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0, 10000000)]
        public decimal Salary { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
