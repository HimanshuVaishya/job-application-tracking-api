using JobTrackerAPI.Models;

namespace JobTrackerAPI.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task AddApplicationAsync(Application pApplication);
        Task<List<Application>> GetAllApplicationsAsync();
        Task<List<Application>> GetAllApplicationsWithDetailsAsync();
        Task<Application> GetApplicationByIDAsync(Int32 pID);
    }
}
