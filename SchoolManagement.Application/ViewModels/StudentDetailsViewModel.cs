namespace SchoolManagement.Application.ViewModels
{
    public class StudentDetailsViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Registration { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public DateTime Created { get; private set; }


        public StudentDetailsViewModel(int id, string name, int registration, string phoneNumber, string email, DateTime created)
        {
            Id = id;
            Name = name;
            Registration = registration;
            PhoneNumber = phoneNumber;
            Email = email;
            Created = created;

        }
    }
}
