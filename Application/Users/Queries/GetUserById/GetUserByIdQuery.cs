﻿using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid Id) : IQuery<UserResponse>; 
}
