using DevFreela.Core.DTOs;
using DevFreela.Core.Reposiotires;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository skillRepository;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await skillRepository.GetAllAsync();
        }
    }
}
