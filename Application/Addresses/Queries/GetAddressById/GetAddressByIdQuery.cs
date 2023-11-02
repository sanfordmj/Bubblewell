using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Queries.GetAddressById
{
    public sealed record GetAddressByIdQuery(Guid Id): IQuery<AddressResponse>;
}
