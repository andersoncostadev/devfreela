using DevFreela.Application.ViewModels;
using DevFreela.Core.Reposiotires;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdProjects
{
    public class GetByIdProjectsQueryHandler : IRequestHandler<GetByIdProjectsQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetByIdProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectsQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null) return null!;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project!.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FulName!,
                project.Freelancer.FulName!
                );

            return projectDetailsViewModel;
        }
    }
}
