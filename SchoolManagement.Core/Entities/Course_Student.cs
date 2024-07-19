namespace SchoolManagement.Core.Entities
{
    public class Course_Student : BaseEntity
    {
        public int StudentId { get; private set; }
        public int CourseId { get; private set; }        
        public Student Student { get; private set; }
        public Course Course { get; private set; }
      
    }
}
