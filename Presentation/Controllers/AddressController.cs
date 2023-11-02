using Application.Addresses.Commands;
using Application.Addresses.Queries.GetAddressById;
using Asp.Versioning;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    //[Route("~/api/address")]
    [ApiVersion(1.0)]
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class AddressController: ApiController
    {
        [HttpGet("addressId:guid"), MapToApiVersion(2.0)]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAddress(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetAddressByIdQuery(Id);
            var address = await Sender.Send(query, cancellationToken);
            return Ok(address);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAddress(
        [FromBody] CreateAddressRequest request,
        CancellationToken cancellationToken)
        {
            var addressCommand = request.Adapt<CreateAddressCommand>();
            var addressId = await Sender.Send(addressCommand, cancellationToken);

            return CreatedAtAction(nameof(GetAddress), new { addressId }, addressId);
            
        }
    }
}
