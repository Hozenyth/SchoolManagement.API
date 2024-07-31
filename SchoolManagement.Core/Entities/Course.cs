using SchoolManagement.Core.Enums;

namespace SchoolManagement.Core.Entities
{
    public class Course : BaseEntity
    {
      
        public string Description { get; private set; }
        public string Title { get; private set; }
        public int? TeacherId { get; private set; }     
        public DateTime StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Teacher Teacher { get; private set; }   
        public List<Student> Students { get; private set; }
        public CourseStatusEnum Status { get; set; }

        public Course(string title, string description)
        {
            Title = title;
            Description = description;            
            CreatedAt = DateTime.Now;
            Status = CourseStatusEnum.Created;
        }

        public void Cancel() 
        {
          
           Status = CourseStatusEnum.Cancelled;
        }

        public void Start()
        {
            if(Status == CourseStatusEnum.Created)
                StartedAt = DateTime.Now;
        }

        public void Finish()
        {
            if (Status == CourseStatusEnum.InProgress)
                Status = CourseStatusEnum.Finished;
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public void UpdateTeacherCourse(int? teacherId)
        {
            TeacherId = teacherId;
            
        }
    }
}
