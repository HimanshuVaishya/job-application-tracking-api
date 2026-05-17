using JobTrackerAPI.Data;
using JobTrackerAPI.Models;
using JobTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddUserAsync(User pUser)
        {
            await _context.Users.AddAsync(pUser);
            _context.SaveChanges();
        }
        public async Task<User> GetUserByEmailAsync(string pEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == pEmail);
        }
        public async Task<Boolean> EmailExistsAsync(string pEmail)
        {
            return await _context.Users.AnyAsync(x => x.Email == pEmail);
        }

    }
}
