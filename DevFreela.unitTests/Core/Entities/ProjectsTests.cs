using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectsTests
    {
        [Fact]
        public void ProjectsStartWorks()
        {
            var project = new Project("Nome do Projeto", "Descrição do Projeto", 1, 2, 10000);

            Assert.Equal(ProjectsStatusEnum.Created, project.Status);
            Assert.NotEmpty(project?.Title!);
            Assert.NotEmpty(project?.Description!);
            Assert.NotNull(project?.Title);
            Assert.NotNull(project?.Description);

            project?.Start();

            Assert.Equal(ProjectsStatusEnum.InProgress, project?.Status);
            Assert.NotNull(project?.StartedAt);
        }
    }
}
