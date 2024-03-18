﻿using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Reposiotires;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Project>> GetAllAsync() => await _dbContext.Projects!.ToListAsync();

        public async Task<Project> GetByIdAsync(int id)
        {
           return await _dbContext.Projects!
                .Include(p => p.Client!)
                .Include(p => p.Freelancer!)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects!.AddAsync(project!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments!.AddAsync(projectComment!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartAsync(Project project)
        {
            using var sqlconnection = new SqlConnection(_connectionString);
            sqlconnection.Open();

            var script = "UPDATE Projects SET Status = @status, StartedAt = @startedAt WHERE Id = @id";

            await sqlconnection.ExecuteAsync(script, new { status = project!.Status, startedAt = project!.StartedAt, project.Id });
        }

        public async Task FinishAsync(Project project)
        {
            using var sqlconnection = new SqlConnection(_connectionString);
            sqlconnection.Open();

            var script = "UPDATE Projects SET Status = @status, FinishedAt = @finishedAt WHERE Id = @id";

            await sqlconnection.ExecuteAsync(script, new { status = project!.Status, finishedAt = project!.FinishedAt, project.Id });
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
