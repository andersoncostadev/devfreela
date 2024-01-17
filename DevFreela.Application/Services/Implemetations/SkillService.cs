using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Application.Services.Implemetations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContext.Skills;

            var skillViewModel = skills!.Select(s => new SkillViewModel(s.Id, s.Description, s.CreatedAt)).ToList();

            return skillViewModel;
        }
    }
}
