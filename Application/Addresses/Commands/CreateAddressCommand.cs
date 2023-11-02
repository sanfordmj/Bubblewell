using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Commands
{
    public sealed record CreateAddressCommand(Guid Id, string street, string city, string state, string zip, double lat, double lng, string comments, bool bagged, DateTime createDate) : ICommand<Guid>;
}
