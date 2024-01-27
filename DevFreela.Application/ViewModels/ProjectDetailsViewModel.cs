﻿namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string? title, string? description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt, string clientFullname, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            ClientFullName = clientFullname;
            FreelancerFullName = freelancerFullName;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime?  StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
    }
}
