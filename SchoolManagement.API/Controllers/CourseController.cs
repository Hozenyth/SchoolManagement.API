using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Comands.CreateCourse;
using SchoolManagement.Application.Comands.DeleteCourse;
using SchoolManagement.Application.Comands.UpdateCourse;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Queries.GetAllCourses;
using SchoolManagement.Application.Services.Interfaces;

namespace SchoolManagement.API.Controllers
{
    [Route("api/Course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMediator _mediator;
        public CourseController(ICourseService courseService, IMediator mediator)
        {
            _courseService = courseService;
            _mediator = mediator;
        }

        [HttpGet("GetAllCourses", Name = "GetAllCourse")]
        public async Task<IActionResult> GetAll(string query) 
        {
            var getAllCoursesQuery = new GetAllCoursesQuery(query);
            var courses = await _mediator.Send(getAllCoursesQuery);

            return Ok(courses);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseService.GetCourse(id);
            
            return course == null ? NotFound() : Ok(course);
        }

        [HttpPost("CreateCourse", Name = "CreateCourse")]
        public async Task<IActionResult> Post([FromBody] CreateCourseCommand command)
        {
            
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("UpdateCourse", Name = "UpdateCourse")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseComand command, int id)
        {
            if (string.IsNullOrEmpty(command.Title))
                return BadRequest();
            else
            {
              await  _mediator.Send(command);
                return Ok();
            }                    
        }

        [HttpDelete("DeleteCourse", Name = "DeleteCourse")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand(id);
            await _mediator.Send(command);           
            return NoContent();
        }

        [HttpPut("UpdateTeacherCourse", Name = "UpdateTeacherCourse")]
        public IActionResult Put([FromBody] UpdateTeacherCourse inputModel)
        {          
            _courseService.UpdateTeacherCourse(inputModel);
            return Ok();
        }
    }
}
