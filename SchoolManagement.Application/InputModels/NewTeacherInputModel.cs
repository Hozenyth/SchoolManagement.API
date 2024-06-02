namespace SchoolManagement.Application.InputModels
{
    public class NewTeacherInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Registration { get; set; }
        public DateTime CreatedAt { get; set; }
       
    }
}
