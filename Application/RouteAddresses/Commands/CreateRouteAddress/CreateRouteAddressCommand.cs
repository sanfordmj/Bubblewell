using System;
using Application.Abstractions.Messaging;

namespace Application.RouteAddresses.Commands.CreateRouteAddress
{
    public sealed record CreateRouteAddressCommand(Guid Id, Guid RouteId, Guid AddressId, bool Visible, bool Reviewed, int Position, DateTime ModifyDate) : ICommand<Guid>;
    
}
