using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;


namespace SchoolManagement.Controllers
{
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get(string query)
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
       
        [HttpGet("{registration}")]
        public IActionResult GetRegistration(int registration)
        {
            return Ok();
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
