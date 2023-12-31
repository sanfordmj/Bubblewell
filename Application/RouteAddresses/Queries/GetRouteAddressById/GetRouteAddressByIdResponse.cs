﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RouteAddresses.Queries.GetRouteAddressById
{
    public sealed record GetRouteAddressByIdResponse(Guid Id, int RouteId, int AddressId, bool Visible, bool Reviewed, int Position, DateTime? UpdatedAt, bool Deleted);
}
