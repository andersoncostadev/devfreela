using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        int Create(NewProjectInputModel newProjectInput );
        void Update(UpdateProjectInputModel updateProjectInput);
        void Delete(int id);
        void CreateComment(CreateCommentInputModel createCommentInput);
        void Start(int id);
        void Finish(int id);
    }
}
