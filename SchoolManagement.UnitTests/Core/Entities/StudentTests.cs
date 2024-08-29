using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Enums;

namespace SchoolManagement.UnitTests.Core.Entities
{
    public class StudentTests
    {
        [Fact]
        public void TestStudentStartWorks()
        {
            var student = new Student("Hoze", "2299999999",2022401,"hoze@teste.com","student","123456");

            Assert.Equal(StudentStatusEnum.Created, student.StudentStatus);

            Assert.NotEmpty(student.Name);
            Assert.NotNull(student.Name);

            Assert.NotEmpty(student.PhoneNumber);
            Assert.NotNull(student.PhoneNumber);
            
            Assert.NotNull(student.Registration);

            Assert.NotEmpty(student.Email);
            Assert.NotNull(student.Email);
                    
            Assert.NotNull(student.CreatedAt);
        }
        [Fact]
        public void TestStudentEndWorks()
        {
            var student = new Student("Hoze", "2299999999", 2022401, "hoze@teste.com", "student", "123456");

            Assert.Equal(StudentStatusEnum.Created, student.StudentStatus);

            Assert.NotEmpty(student.Name);
            Assert.NotNull(student.Name);

            Assert.NotEmpty(student.PhoneNumber);
            Assert.NotNull(student.PhoneNumber);

            Assert.NotNull(student.Registration);

            Assert.NotEmpty(student.Email);
            Assert.NotNull(student.Email);

            student.Cancel();

            Assert.Equal(StudentStatusEnum.Cancelled, student.StudentStatus);
            Assert.NotNull(student.CreatedAt);
        }

    }
    
}
