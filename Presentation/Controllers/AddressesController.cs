using Application.Addresses.Commands.CreateAddress;
using Application.Addresses.Queries.GetAddressById;
using Asp.Versioning;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

    [ApiVersion(1.0)]
    [ApiVersion(2.0)]
    [Route("api/v{version:ApiVersion}/[Controller]")]
    [ApiController]
    public sealed class AddressesController: ApiController
    {
        
        [HttpGet("addressId:guid"), MapToApiVersion(1.0)]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAddress(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetAddressByIdQuery(Id);
            var address = await Sender.Send(query, cancellationToken);
            return Ok(address);
        }
        
        /* Example of version 2 working, but swagger crashes dut to multiple same type actions
        [HttpGet("addressId:guid"), MapToApiVersion(2.0)]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAddressV2(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetAddressByIdQuery(Id);
            var address = await Sender.Send(query, cancellationToken);
            return Ok(address);
        }
        */
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
