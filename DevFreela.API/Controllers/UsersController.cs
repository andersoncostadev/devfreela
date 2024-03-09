using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
           var getUserQuery = new GetUserQuery(id);

            var user = _mediator.Send(getUserQuery);

            if(user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var user = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById),new { user }, command);
        }

        [HttpPut("{id}/login")]
        public IActionResult Result(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }
    }
}
