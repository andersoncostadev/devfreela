using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implemetations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProjectInputModel newProjectInput)
        {
            var project = new Project
                (newProjectInput.Title, newProjectInput.Description, newProjectInput.IdClient, newProjectInput.IdFreelancer, newProjectInput.TotalCost);

            _dbContext.Projects!.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel createCommentInput)
        {
            var commentProject = new ProjectComment(createCommentInput.Content, createCommentInput.IdProject, createCommentInput.IdUser);

            _dbContext.ProjectComments!.Add(commentProject);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects!.SingleOrDefault(p => p.Id == id);

            project!.Cancel();

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects!.SingleOrDefault(p => p.Id == id);

            project?.Finish();

            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects!.Select(p => new ProjectViewModel(p.Title, p.CreatedAt)).ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext?.Projects!.SingleOrDefault(p => p.Id == id);

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

        public void Start(int id)
        {
            var project = _dbContext.Projects!.SingleOrDefault(p => p.Id == id);

            project?.Start();

            _dbContext.SaveChanges();
        }

        public void Update(UpdateProjectInputModel updateProjectInput)
        {
            var project = _dbContext.Projects!
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == updateProjectInput.Id);

            project!.Update(updateProjectInput.Title!, updateProjectInput.Description!, updateProjectInput.TotalCost);

            _dbContext.SaveChanges();

        }
    }
}
