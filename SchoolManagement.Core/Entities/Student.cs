﻿namespace SchoolManagement.Core.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Registration { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Course> Courses { get; private set; }

        public Student( string name, string phoneNumber, int registration, string email) 
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Registration = registration;
            Email = email;
            CreatedAt = DateTime.Now;
            IsActive = true;

            Courses = new List<Course>();
        }
    }
}
