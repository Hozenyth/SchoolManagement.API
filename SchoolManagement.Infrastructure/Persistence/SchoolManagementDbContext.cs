

using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Persistence
{
    public class SchoolManagementDbContext
    {
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

        public SchoolManagementDbContext()
        {
            Students = new List<Student>
            {
                new Student("Hozenyth", "2227738053", 2024001,"hozenyth.teste@gmail.com"),
                new Student("Alexander", "2227715283", 2024002,"alex.teste@gmail.com"),
                new Student("Marina", "2227715283", 2024003,"marina.teste@gmail.com")
            };

            Teachers = new List<Teacher>
            {
                new Teacher("Rodrigo", "rdgr@gmail.com", 01, "22999542651"),
                new Teacher("Paulo", "aulo@gmail.com", 02, "22888745212"),
            };

            Courses = new List<Course>
            {
                new Course("Javascript"),
                new Course("Program Logic"),
                new Course("Power BI"),
                new Course("Excell")
            };
        }
    }
}
