using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Reposiotires;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectsViewModel()
        {
            // Arrange
            var projects = new List<Project>
            {
                new("Project 1", "Description 1", 1, 2, 10000),
                new("Project 2", "Description 2", 1, 2, 20000),
                new("Project 3", "Description 3", 1, 2, 30000)
            };

            var projectsRepositoryMock = new Mock<IProjectRepository>();
            projectsRepositoryMock.Setup(pr => pr.GetAllAsync()).ReturnsAsync(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsCommandHandler = new GetAllProjectsQueryHandler(projectsRepositoryMock.Object);

            projectsRepositoryMock.Setup(pr => pr.GetAllAsync()).ReturnsAsync(projects);

            // Act
            var projectsViewModel = await getAllProjectsCommandHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectsViewModel);
            Assert.NotEmpty(projectsViewModel);
            Assert.Equal(projects.Count, projectsViewModel.Count);

            projectsRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
