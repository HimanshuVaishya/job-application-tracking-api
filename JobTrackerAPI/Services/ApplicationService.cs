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
        private readonly IFileService _fileService;
        public ApplicationService(IJobRepository jobRepository, IApplicationRepository applicationRepository, IFileService fileService)
        {
            this._jobRepository = jobRepository;
            this._applicationRepository = applicationRepository;
            _fileService = fileService;
        }
        public async Task<string> ApplyJobAsync(int userId, ApplyJobDto dto)
        {
            var job = await _jobRepository.GetJobByIDAsync(dto.JobId);

            if (job == null)
                return "Job not found";

            var existingApplication = await _applicationRepository.GetApplicationByUserAndJobAsync(userId, dto.JobId);

            if (existingApplication != null)
                return "Already applied";

            // File saving logic moved here
            var resumePath = await _fileService.SaveResumeAsync(dto.Resume);

            var application = new Application
            {
                UserId = userId,
                JobId = dto.JobId,
                ResumePath = resumePath,
                Status = "applied",
                AppliedDate = DateTime.UtcNow
            };

            await _applicationRepository.AddApplicationAsync(application);

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

            await _applicationRepository.UpdateApplicationAsync(application);

            return "Status updated successfully";
        }
    }
}