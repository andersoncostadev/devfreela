﻿namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string? content, int idProjetc, int idUser)
        {
            Content = content;
            IdProjetc = idProjetc;
            IdUser = idUser;
        }

        public string? Content { get; private set; }
        public Project Project { get; private set; }
        public int IdProjetc { get; private set; }
        public User User { get; private set; }
        public int IdUser { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
