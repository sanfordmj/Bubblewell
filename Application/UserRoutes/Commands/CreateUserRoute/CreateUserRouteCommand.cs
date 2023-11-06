﻿using System;
using Application.Abstractions.Messaging;

namespace Application.UserRoutes.Commands.CreateUserRoute
{
    public sealed record CreateUserRouteCommand(Guid Id, Guid UserId, Guid RouteId): ICommand<Guid>;
    
}
