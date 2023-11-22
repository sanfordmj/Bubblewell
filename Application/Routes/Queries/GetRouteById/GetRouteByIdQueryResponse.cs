using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routes.Queries.GetRouteById
{
    public sealed record GetRouteByIdQueryResponse(Guid Id, RouteStatus RouteStatus, RouteType RouteType, string Name, DateTime CreateDate, DateTime? UpdatedAt, bool Deleted);
}
