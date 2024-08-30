using Moq;
using SchoolManagement.Application.Comands.CreateStudent;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Core.Services;

namespace SchoolManagement.UnitTests.Application.Commands
{
    public class CreateStudentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnStudentId()
        {
            //Arrange
            var studentRepository = new Mock<IStudentRepository>();
            var authService = new Mock<IAuthService>();

            var createStudentCommand = new CreateStudentCommand
            {
                Email = "teste@teste.com",
                Name = "name",
                PhoneNumber = "1234567890",
                Registration = 1,
                Password = "password",
                Role = "student"               
            };
          
            var createStudentCommandHandler = new CreateStudentCommandHandler(studentRepository.Object, authService.Object);

            //Act

            var id = await createStudentCommandHandler.Handle(createStudentCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);
            studentRepository.Verify(c => c.AddAsync(It.IsAny<Student>()), Times.Once);
        }
    }
}
