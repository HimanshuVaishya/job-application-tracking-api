using JobTrackerAPI.DTOs;
using JobTrackerAPI.Models;
using JobTrackerAPI.Repositories.Interfaces;
using JobTrackerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationService(IJobRepository jobRepository, IApplicationRepository applicationRepository)
        {
            this._jobRepository = jobRepository;
            this._applicationRepository = applicationRepository;
        }
        public async Task<string> ApplyJobAsync(int userId, ApplyJobDto dto)
        {

            var job = await _jobRepository.GetJobByIDAsync(dto.JobId);

            if (job == null) return "Job not found";

            var lstApplications = await _applicationRepository.GetAllApplicationsAsync();

            if (lstApplications.Any(x => x.UserId == userId && x.JobId == dto.JobId)) return "Already applied";

            var application = new Application
            {
                UserId = userId,
                JobId = dto.JobId,
                ResumePath = dto.ResumePath,
                Status = "applied",
                AppliedDate = DateTime.UtcNow
            };

            _applicationRepository.AddApplicationAsync(application);

            return "Applied successfully";
        }

        public async Task<List<Application>> GetApplicationsAsync()
        {
            return await _applicationRepository.GetAllApplicationsWithDetailsAsync();
        }

        public async Task<string> UpdateStatusAsync(int applicationId, string status)
        {
            var application = await _applicationRepository.GetApplicationByIDAsync(applicationId);

            if (application == null)
                return "Application not found";

            var validStatuses = new[]
            {
                "Applied",
                "Shortlisted",
                "Interview Scheduled",
                "Rejected",
                "Selected"
            };

            if (!validStatuses.Contains(status))
                return "Invalid status";

            application.Status = status;

            _applicationRepository.AddApplicationAsync(application);

            return "Status updated successfully";
        }
    }
}