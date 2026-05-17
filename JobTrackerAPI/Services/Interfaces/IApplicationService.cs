using JobTrackerAPI.DTOs;
using JobTrackerAPI.Models;

namespace JobTrackerAPI.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<string> ApplyJobAsync(int userId, ApplyJobDto dto);
        Task<List<Application>> GetApplicationsAsync();
        Task<string> UpdateStatusAsync(int applicationId, string status);
    }
}
