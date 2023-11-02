﻿using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RouteAddresses.Queries.GetRouteAddressById
{
    public sealed record GetRouteAddressByIdQuery(Guid Id) : IQuery<RouteAddressResponse>;
}
