using Asp.Versioning;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Services;

namespace Presentation.TableControllers
{
    [AllowAnonymous]    
    [Route("tables/[Controller]")]    
    public class AddressController : Controller
    {
        ISyncService<Address> _syncService;
        public AddressController(ISyncService<Address> syncService)
        {
            _syncService = syncService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemsAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Address> addresses = await _syncService.GetItemsAsync();
            return Ok(addresses);
        }

    }
}
