using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserAddresses.Queries.GetUserAddressById
{
    public sealed record GetUserAddressByIdQuery(Guid Id) : IQuery<GetUserAddressByIdQueryResponse>;
}
