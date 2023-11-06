using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RouteAddressPublishers.Queries.GetRouteAddressPublisherById
{
    public sealed record GetRouteAddressPublisherByIdQuery(Guid Id) : IQuery<GetRouteAddressPublisherByIdQueryResponse>;
}
