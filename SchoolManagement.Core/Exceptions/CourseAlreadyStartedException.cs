namespace SchoolManagement.Core.Exceptions
{
    public class CourseAlreadyStartedException : Exception
    {
        public CourseAlreadyStartedException() : base("Project is already in Started status")
        {
            
        }
    }
}
