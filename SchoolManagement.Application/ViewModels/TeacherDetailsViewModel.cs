namespace SchoolManagement.Application.ViewModels
{
    public class TeacherDetailsViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Registration { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public TeacherDetailsViewModel( int id, string name, string phoneNumber, int registration)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Registration = registration;
           
        }

    }
}
