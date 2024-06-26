﻿using SchoolManagement.Core.Enums;

namespace SchoolManagement.Core.Entities
{
    public class Course : BaseEntity
    {
      
        public string Description { get; private set; }
        public string Title { get; private set; }
        public int IdTeacher { get; private set; }
        public int IdStudant { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }

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
            if (Status == CourseStatusEnum.InProgress)
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
    }
}
