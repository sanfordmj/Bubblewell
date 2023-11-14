using Application.Abstractions.Messaging;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Commands.CreateAddress
{
    public sealed record CreateAddressCommand(Guid Id, AddressStatus addressStatus, AddressType addressType, string street, string city, string state, string zip, double lat, double lng, string comments, bool bagged, DateTime createDate, byte[] Version, DateTimeOffset UpdatedAt, bool Deleted) : ICommand<Guid>;
}
