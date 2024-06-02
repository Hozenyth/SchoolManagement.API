using SchoolManagement.Core.Enums;

namespace SchoolManagement.Application.InputModels
{
    public class NewStudentInputModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Registration { get; set; }
                   
    }
}
