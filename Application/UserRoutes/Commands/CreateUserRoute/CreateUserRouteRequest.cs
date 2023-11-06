using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserRoutes.Commands.CreateUserRoute
{
    public sealed record CreateUserRouteRequest(Guid UserId, Guid RouteId);
}
