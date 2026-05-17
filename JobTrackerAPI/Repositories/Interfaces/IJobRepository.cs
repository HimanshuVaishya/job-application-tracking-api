using JobTrackerAPI.Models;

namespace JobTrackerAPI.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task AddJobAsync(Job pJob);
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIDAsync(Int32 pID);
    }
}
