using System;
using Application.Abstractions.Messaging;
using Domain.Primitives;

namespace Application.Routes.Commands.CreateRoute
{
    public sealed record CreateRouteCommand(Guid Id, RouteStatus RouteStatus, RouteType RouteType, string Name, DateTime CreateDate): ICommand<Guid>;
    
}
