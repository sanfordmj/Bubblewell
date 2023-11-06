using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Queries.GetUserTokenById
{
    public sealed record GetUserTokenByIdQuery(Guid Id) : IQuery<GetUserTokenByIdQueryResponse>; 
}
