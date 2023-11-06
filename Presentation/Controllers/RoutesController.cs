using Application.Routes.Commands.CreateRoute;
using Application.Routes.Queries.GetRouteById;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    //[Route("~/api/route")]
    public sealed class RoutesController : ApiController
    {

        [HttpGet("routeId:guid")]
        [ProducesResponseType(typeof(GetRouteByIdQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoute(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetRouteByIdQuery(Id);
            var route = await Sender.Send(query, cancellationToken);
            return Ok(route);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRoute(
        [FromBody] CreateRouteRequest request,
        CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateRouteCommand>();
            var routeId = await Sender.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetRoute), new { routeId }, routeId);
        }

    }
}
