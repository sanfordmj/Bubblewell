using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RouteAddressPublishers.Commands.CreateRouteAddressPublisher
{
    public sealed record CreateRouteAddressPublisherRequest(Guid routeAddressId, Guid publisherId);
}
