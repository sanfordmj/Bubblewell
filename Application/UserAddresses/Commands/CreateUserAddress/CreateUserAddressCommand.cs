using System;
using Application.Abstractions.Messaging;

namespace Application.UserAddresses.Commands.CreateUserAddress
{
    public sealed record CreateUserAddressCommand(Guid Id, Guid UserId, Guid AddressId, bool Visible, DateTime ModifyDate): ICommand<Guid>;
    
}
