using JobTrackerAPI.DTOs;

namespace JobTrackerAPI.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}
