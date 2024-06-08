﻿namespace SchoolManagement.Application.InputModels
{
    public class UpdateTeacherInputModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Registration { get; private set; }

        public UpdateTeacherInputModel(string name, string email, string phoneNumber, int registration)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Registration = registration;
        }
    }
}
