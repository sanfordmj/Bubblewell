using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RouteAddresses.Commands.CreateRouteAddress
{
    public sealed record CreateRouteAddressRequest(Guid RouteId, Guid AddressId, bool Visible, bool Reviewed, int Position, DateTime ModifyDate);
}
