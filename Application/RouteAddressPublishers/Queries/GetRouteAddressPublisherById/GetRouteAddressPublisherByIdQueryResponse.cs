using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RouteAddressPublishers.Queries.GetRouteAddressPublisherById
{
    public sealed record GetRouteAddressPublisherByIdQueryResponse(Guid Id, Guid RouteAddressId, Guid PublisherId, DateTime? UpdatedAt, bool Deleted);
}
