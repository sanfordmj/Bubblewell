using Application.Routes.Commands.CreateRoute;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserById;
using Asp.Versioning;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiVersion(1.0)]
    [ApiVersion(2.0)]
    [Route("api/v{version:ApiVersion}/[Controller]")]
    [ApiController]
    [AllowAnonymous]
    public sealed class UserController : ApiController
    {

        [HttpGet("userId:guid")]
        [ProducesResponseType(typeof(GetUserByIdQuery), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery(Id);
            var user = await Sender.Send(query, cancellationToken);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateUserCommand>();
            var userId = await Sender.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetUser), new { userId }, userId);
        }
    }
}
