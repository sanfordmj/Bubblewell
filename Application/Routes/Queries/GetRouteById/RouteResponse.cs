using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routes.Queries.GetRouteById
{
    public sealed record RouteResponse(Guid Id, RouteStatus RouteStatus, RouteType RouteType, string Name, DateTime CreateDate);
}
