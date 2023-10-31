using System;
using Application.Abstractions.Messaging;

namespace Application.Routes.Commands.CreateRoute
{
    public sealed record CreateRouteCommand(Guid Id, string Name, DateTime CreateDate): ICommand<Guid>;
    
}
