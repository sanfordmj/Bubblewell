using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Queries.GetUserTokenByToken
{
    public sealed record GetUserTokenByTokenQuery(Guid Id) : IQuery<GetUserTokenByTokenQueryResponse>; 
}
