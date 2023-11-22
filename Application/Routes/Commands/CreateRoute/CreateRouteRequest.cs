using Domain.Primitives;

namespace Application.Routes.Commands.CreateRoute
{
    public sealed record CreateRouteRequest(RouteStatus RouteStatus, RouteType RouteType, string Name, DateTime CreateDate, DateTime? UpdatedAt, bool Deleted);
}
