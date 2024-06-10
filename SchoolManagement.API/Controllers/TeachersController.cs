using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Interfaces;

namespace SchoolManagement.API.Controllers
{
    [Route("api/Teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService) 
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var teachers = _teacherService.GetAllTeachers();
            
            return Ok(teachers);
        }

        [HttpGet("{registration}")]
        public IActionResult GetTeacher(int registration)
        {
            var teacher = _teacherService.GetTeacherDetails(registration);
            
            return Ok(teacher);
        }
      

        [HttpPost("CreateTeacher", Name = "CreateTeacher")]
        public IActionResult Post([FromBody] NewTeacherInputModel inputModel) 
        {
            var registration = _teacherService.CreateNewTeacher(inputModel);

            return CreatedAtAction(nameof(GetTeacher), new { registration = registration }, inputModel);
        }

        [HttpDelete]
        public IActionResult DeleteRegistration(int registration) 
        {
            _teacherService.DeleteTeacher(registration);
           
            return NoContent();
        }

        [HttpPut("UpdateTeacher", Name = "Updateteacher")]
        public IActionResult Put([FromBody] UpdateTeacherInputModel inputModel, int registration) 
        {
            if(inputModel.Name == null )          
              return BadRequest();
            
            _teacherService.UpdateTeacher(inputModel, registration);
            return NoContent();
        }

    }
}
