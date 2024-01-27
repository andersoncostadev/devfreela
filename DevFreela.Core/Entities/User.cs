namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string? fulName, string? email, DateTime birthDate)
        {
            FulName = fulName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
            Active = true;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreeLanceProjects = new List<Project>();
            Comments = new List<ProjectComment>();
        }

        public string? FulName { get; private set; }
        public string? Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public List<UserSkill>? Skills { get; private set; }
        public List<Project>? OwnedProjects { get; private set; }
        public List<Project>? FreeLanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
