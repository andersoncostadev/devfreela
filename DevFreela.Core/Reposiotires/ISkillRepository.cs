using DevFreela.Core.DTOs;

namespace DevFreela.Core.Reposiotires
{
    public interface ISkillRepository
    {
        Task <List<SkillDTO>> GetAllAsync();
    }
}
