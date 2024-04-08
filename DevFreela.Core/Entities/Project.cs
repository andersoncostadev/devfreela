using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {

        public Project(string? title, string? description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            CreatedAt = DateTime.Now;
            Status = ProjectsStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public User Client { get; private set; }
        public int IdClient { get; private set; }
        public User Freelancer { get; private set; }
        public int IdFreelancer { get; private set;}
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public ProjectsStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if(Status == ProjectsStatusEnum.InProgress || Status == ProjectsStatusEnum.Created)
            {
                Status = ProjectsStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if(Status == ProjectsStatusEnum.Created)
            {
                Status = ProjectsStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if (Status == ProjectsStatusEnum.InProgress)
            {
                Status = ProjectsStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void Update(string title, string descrption, decimal totalCost)
        {
            Title = title;
            Description = descrption;
            TotalCost = totalCost;
        }
    }
}
