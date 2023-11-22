using System;
using Application.Abstractions.Messaging;

namespace Application.UserRoutes.Commands.CreateUserRoute
{
    public sealed record CreateUserRouteCommand(Guid Id, Guid UserId, Guid RouteId, DateTime? UpdatedAt, bool Deleted) : ICommand<Guid>;
    
}
