using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routes.Queries.GetRouteById
{
    public sealed record GetRouteByIdQuery(Guid Id) : IQuery<RouteResponse>;
}
