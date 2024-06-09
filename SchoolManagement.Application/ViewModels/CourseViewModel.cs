namespace SchoolManagement.Application.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        DateTime CreatedAt { get; set; }        
        DateTime? StartedAt { get; set; }
        DateTime? FinishedAt { get; set; }

        public CourseViewModel(int id, string title, string description, DateTime createdAt, DateTime startedAt, DateTime finishedAt)
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
