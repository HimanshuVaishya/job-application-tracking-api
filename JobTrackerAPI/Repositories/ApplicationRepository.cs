using JobTrackerAPI.Data;
using JobTrackerAPI.Models;
using JobTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;
        public ApplicationRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task AddApplicationAsync(Application pApplication)
        {
            await _context.Applications.AddAsync(pApplication);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateApplicationAsync(Application pApplication)
        {
            _context.Applications.Update(pApplication);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Application>> GetAllApplicationsAsync()
        {
            return await _context.Applications.ToListAsync();
        }
        public async Task<List<Application>> GetAllApplicationsWithDetailsAsync()
        {
            return await _context.Applications
                .Include(x => x.User)
                .Include(x => x.Job)
                .ToListAsync();
        }
        public async Task<Application> GetApplicationByIDAsync(Int32 pID)
        {
            return await _context.Applications.FindAsync(pID);
        }
        public async Task<Application?> GetApplicationByUserAndJobAsync(int pUserId, int pJobId)
        {
            return await _context.Applications.FirstOrDefaultAsync(x => x.UserId == pUserId && x.JobId == pJobId);
        }
    }
}
