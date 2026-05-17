namespace JobTrackerAPI.DTOs
{
    public class DashboardDto
    {
        public int TotalJobs { get; set; }
        public int TotalApplications { get; set; }
        public int SelectedCandidates { get; set; }
        public int RejectedCandidates { get; set; }
    }
}
