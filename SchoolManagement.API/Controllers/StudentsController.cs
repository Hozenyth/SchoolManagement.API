using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.Application.Services.Interfaces;

namespace SchoolManagement.Controllers
{
   
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
                
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var students = _studentService.GetAll(query);
            return Ok(students);
        }

        [HttpGet("{registration}")]
        public IActionResult GetById(int registration)
        {
            var student = _studentService.GetByRegistration(registration);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
              
        [HttpPost("CreateStudent", Name = "CreateStudent")]
        public IActionResult CreateStudent([FromBody] CreateStudentsModel createStudent)
        {

            return Ok(createStudent);
        }

        [HttpPut("UpdateStudent", Name = "UpdateStudent")]       
        public IActionResult UpdateStudent([FromForm] UpdateStudentModel updateStudent) 
        { 
            return Ok(updateStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return NoContent();
        }
    }
}
