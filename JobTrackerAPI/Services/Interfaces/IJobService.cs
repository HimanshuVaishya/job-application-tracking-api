using JobTrackerAPI.DTOs;
using JobTrackerAPI.Models;

namespace JobTrackerAPI.Services.Interfaces
{
    public interface IJobService
    {
        Task<Job> CreateJobAsync(CreateJobDto dto);
        Task<List<Job>> GetAllJobsAsync();
    }
}
