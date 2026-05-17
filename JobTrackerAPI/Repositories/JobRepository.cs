using JobTrackerAPI.Data;
using JobTrackerAPI.Models;
using JobTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;
        public JobRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task AddJobAsync(Job pJob)
        {
            await _context.Jobs.AddAsync(pJob);
        }
        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobByIDAsync(Int32 pID)
        {
            return await _context.Jobs.FindAsync(pID);
        }
    }
}
