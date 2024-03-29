﻿using DevFreela.Core.Entities;
using DevFreela.Core.Reposiotires;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id) => await _dbContext.Users!.SingleOrDefaultAsync(u => u.Id == id);

        public async Task AddAsync(User user)
        {
            await _dbContext.Users!.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

    }
}
