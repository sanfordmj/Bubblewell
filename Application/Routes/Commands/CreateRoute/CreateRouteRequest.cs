using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routes.Commands.CreateRoute
{
    public sealed record CreateRouteRequest(RouteStatus RouteStatus, RouteType RouteType, string Name, DateTime CreateDate);
}
