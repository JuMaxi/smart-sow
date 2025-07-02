using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Infra.Db;

namespace SmartTray.Infra.DbAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartTrayDbContext _dbContext;

        // Create constructor to work with the database 
        public UserRepository(SmartTrayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Method to insert an user into the database
        public async Task Insert(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        // Method to fetch an user from the database by Id
        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        // Method to Update an user into the database
        public async Task Update(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        // Method to Delete an user from the database by Id
        public async Task Delete(int id)
        {
            _dbContext.Users.Remove(await GetById(id));
            await _dbContext.SaveChangesAsync();
        }
    }
}
