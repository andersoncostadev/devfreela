using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdProjects
{
    public class GetByIdProjectsQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetByIdProjectsQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
