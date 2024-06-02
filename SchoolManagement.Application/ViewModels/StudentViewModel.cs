namespace SchoolManagement.Application.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Registration { get; private set; }

        public StudentViewModel(int id, string name, int registrationn)
        {
            Id = id;
            Name = name;
            Registration = registrationn;
        }
    }
}
