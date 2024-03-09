using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetByIdProjects
{
    public class GetByIdProjectsQueryHandler : IRequestHandler<GetByIdProjectsQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetByIdProjectsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectsQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects!
                .Include(p => p.Client!)
                .Include(p => p.Freelancer!)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

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
