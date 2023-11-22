using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Queries.GetUserTokenByToken
{
    public sealed record GetUserTokenByTokenQueryResponse(Guid Id, Guid UserId, string Token, DateTime? CreateDate, DateTime? ExpireDate, bool IsExpired, bool IsRevoked, DateTime? UpdatedAt, bool Deleted);
}
