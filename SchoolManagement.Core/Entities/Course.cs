using SchoolManagement.Core.Enums;

namespace SchoolManagement.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Description { get; private set; }
        public int IdTeacher { get; private set; }
        public int IdStudant { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public CourseStatusEnum Status { get; set; }

        public Course(string description)
        {
                      
            Description = description;           
            CreatedAt = DateTime.Now;
            Status = CourseStatusEnum.Created;
        }
    }
}
