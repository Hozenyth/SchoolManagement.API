namespace SchoolManagement.Core.Entities
{
    public class Course_Student : BaseEntity
    {
        public int IdStudent { get; private set; }
        public int IdCourse { get; private set; }
        public Student Student { get; private set; }
        public Course Course { get; private set; }
       
    }
}
