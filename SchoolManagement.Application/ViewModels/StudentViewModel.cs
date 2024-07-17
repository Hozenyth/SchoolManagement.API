namespace SchoolManagement.Application.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Registration { get; private set; }

        public StudentViewModel(int id, string name, int registration, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            Registration = registration;
        }
    }
}
