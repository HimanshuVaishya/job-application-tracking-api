using JobTrackerAPI.DTOs;
using JobTrackerAPI.Models;
using JobTrackerAPI.Repositories.Interfaces;
using JobTrackerAPI.Services.Interfaces;

namespace JobTrackerAPI.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            this._jobRepository = jobRepository;
        }

        public async Task<Job> CreateJobAsync(CreateJobDto dto)
        {
            Job lJob = new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                Salary = dto.Salary,
                Location = dto.Location,
                Status = "Open"
            };

            await _jobRepository.AddJobAsync(lJob);
            return lJob;
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllJobsAsync();
        }

    }
}
