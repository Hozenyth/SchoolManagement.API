using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Implementations;
using SchoolManagement.Application.Services.Interfaces;

namespace SchoolManagement.API.Controllers
{
    [Route("api/Course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
            
        }

        [HttpGet("GetAllCourses", Name = "GetAllCourse")]
        public IActionResult GetAll(string query) 
        {
            var courses = _courseService.GetAll(query);

            return Ok(courses);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseService.GetCourse(id);
            
            return course == null ? NotFound() : Ok(course);
        }

        [HttpPost("CreateCourse", Name = "CreateCourse")]
        public IActionResult Post([FromBody] NewCourseInputModel inputModel)
        {
            var course = _courseService.CreateCourse(inputModel);
            return Ok(course);
        }

        [HttpPut("UpdateCourse", Name = "UpdateCourse")]
        public IActionResult Put([FromBody] UpdateCourseInputModel inputModel)
        {
            if (string.IsNullOrEmpty(inputModel.Title))
                return BadRequest();
           
            _courseService.UpdateCourse(inputModel);
            return Ok();
        }

        [HttpDelete("DeleteCourse", Name = "DeleteCourse")]
        public IActionResult Delete(int id)
        {
            _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}
