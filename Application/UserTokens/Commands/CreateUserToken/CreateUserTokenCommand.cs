using Application.Abstractions.Messaging;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Commands.CreateUserToken
{
    public sealed record CreateUserTokenCommand(Guid Id, Guid UserId, string Token, DateTime CreateDate, DateTime ExpireDate, bool IsExpired, bool IsRevoked) : ICommand<Guid>;
}
