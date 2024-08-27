using Moq;
using SchoolManagement.Application.Queries.GetAllCourses;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;
using Xunit;

namespace SchoolManagement.UnitTests.Application.Queries
{
    public class GetAllCoursesCommandHandlerTests
    {
        [Fact]
        public async Task ThreeCoursesExist_Executed_ReturnThreeCourseViewModels()
        {
            //Arrange
            var courses = new List<Course>
            {
                new Course("Name Course 1", "Description test 1"),
                new Course("Name Course 2", "Description test 2"),
                new Course("Name Course 3", "Description test 3"),
            };

            var courseRepositoryMock = new Mock<ICourseRepository>();
            courseRepositoryMock.Setup( c => c.GetAllAsync().Result).Returns(courses);

            var getAllCOursesQuery = new GetAllCoursesQuery("");
            var getAllCOursesQueryHandler = new GetAllCoursesQueryHandler(courseRepositoryMock.Object);
           
            //Act

            var courseViewModelList = await getAllCOursesQueryHandler.Handle(getAllCOursesQuery, new CancellationToken());

            //Assert

            Assert.NotNull(courseViewModelList);
            Assert.NotEmpty(courseViewModelList);
            Assert.Equal(courses.Count, courseViewModelList.Count);

            courseRepositoryMock.Verify(c => c.GetAllAsync().Result, Times.Once());

        }

    }
}
