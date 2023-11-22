using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserRoutes.Queries.GetUserRouteById
{
    public sealed record GetUserRouteByIdQueryResponse(Guid Id, Guid UserId, Guid RouteId, DateTime? UpdatedAt, bool Deleted);
}
