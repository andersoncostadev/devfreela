using DevFreela.Core.Entities;

namespace DevFreela.Core.Reposiotires
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);
        Task StartAsync(Project project);
        Task FinishAsync(Project project);
        Task SaveChangesAsync();
    }
}
