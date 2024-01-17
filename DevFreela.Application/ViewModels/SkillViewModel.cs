namespace DevFreela.Application.ViewModels
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string? descrption, DateTime createdAt)
        {
            Id = id;
            Description = descrption;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
