namespace JobTrackerAPI.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveResumeAsync(IFormFile pFile);
    }
}
