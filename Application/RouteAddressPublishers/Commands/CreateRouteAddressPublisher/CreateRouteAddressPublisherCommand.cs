using System;
using Application.Abstractions.Messaging;

namespace Application.RouteAddressPublishers.Commands.CreateRouteAddressPublisher
{
    public sealed record CreateRouteAddressPublisherCommand(Guid Id, Guid RouteAddressId, Guid PublisherId) : ICommand<Guid>;
    
}
