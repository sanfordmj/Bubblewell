﻿using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserRoutes.Queries.GetUserRouteById
{
    public sealed record GetUserRouteByIdQuery(Guid Id) : IQuery<GetUserRouteByIdQueryResponse>;
}
