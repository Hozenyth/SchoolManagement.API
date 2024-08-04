namespace SchoolManagement.Application.ViewModels
{
    public class TeacherDetailsViewModel
    {       
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Registration { get; private set; }
       
        public TeacherDetailsViewModel( string name, string phoneNumber, int registration)
        {           
            Name = name;
            PhoneNumber = phoneNumber;
            Registration = registration;           
        }

    }
}
