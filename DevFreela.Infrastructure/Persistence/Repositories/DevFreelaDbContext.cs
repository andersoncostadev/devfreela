using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Anderson Costa", "anderson@email.com.br", new DateTime(1988,8,22)),
                new User("Mayara Costa", "mayara@email.com.br", new DateTime(1990,8,16)),
                new User("Douglas Costa", "douglas@email.com.br", new DateTime(1992,8,03)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project>? Projects { get; set; }
        public List<User>? Users { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<ProjectComment>? ProjectComments { get; set; }
    }
}