using DevFreela.Core.Entities;

namespace DevFreela.Core.Reposiotires
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
    }
}
