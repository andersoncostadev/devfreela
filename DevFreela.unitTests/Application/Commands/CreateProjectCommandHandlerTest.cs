using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Reposiotires;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ProjectCreated()
        {
            // Arrange
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Project 1",
                Description = "Description 1",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 10000
            };

            var projectRepository = new Mock<IProjectRepository>();
            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

            // Act
            await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            projectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
