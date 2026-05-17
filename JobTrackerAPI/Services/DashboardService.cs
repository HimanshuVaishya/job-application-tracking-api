using JobTrackerAPI.DTOs;
using JobTrackerAPI.Repositories.Interfaces;
using JobTrackerAPI.Services.Interfaces;

namespace JobTrackerAPI.Services
{
    public class DashboardService : IDashboardService
    {

        private readonly IApplicationRepository _applicationRepository;
        private readonly IJobRepository _jobRepository;
        public DashboardService(IApplicationRepository applicationRepository, IJobRepository jobRepository)
        {
            this._applicationRepository = applicationRepository;
            this._jobRepository = jobRepository;
        }
        public async Task<DashboardDto> GetDashboardAsync()
        {
            var applications = await _applicationRepository.GetAllApplicationsAsync();

            DashboardDto dto = new DashboardDto()
            {
                TotalJobs = (await _jobRepository.GetAllJobsAsync()).Count(),
                TotalApplications = applications.Count(),
                SelectedCandidates = applications.Count(x => x.Status == "Selected"),
                RejectedCandidates = applications.Count(x => x.Status == "Rejected"),
            };

            return dto;
        }
    }
}
