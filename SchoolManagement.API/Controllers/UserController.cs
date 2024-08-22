using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Commands.LoginUser;

namespace SchoolManagement.Controllers
{

    [Route("api/login")]
    public class UserController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public UserController( IMediator mediator)
        {           
            _mediator = mediator;
        }
      

        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);
            if(loginUserViewModel == null)  
                return BadRequest();

            return Ok(loginUserViewModel);
        }

    }
}
