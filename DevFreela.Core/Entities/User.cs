namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string? fulName, string? email, DateTime birthDate, string? password, string? role)
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
            Password = password;
            Role = role;
        }

        public string? FulName { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public string? Role { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public List<UserSkill>? Skills { get; private set; }
        public List<Project>? OwnedProjects { get; private set; }
        public List<Project>? FreeLanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
