using SchoolManagement.Core.Enums;

namespace SchoolManagement.Application.ViewModels
{
    public class CourseDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }        
        public DateTime? CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }

        public CourseDetailsViewModel(int id, string title, string description, DateTime? createdAt, DateTime? startedAt, DateTime? finishedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            StartedAt = startedAt;
            FinishedAt = finishedAt;            
        }
    }
}
