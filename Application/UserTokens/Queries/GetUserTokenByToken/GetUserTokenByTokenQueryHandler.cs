using Application.Abstractions.Messaging;
using Application.UserTokens.Queries.GetUserTokenByToken;
using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Queries.GetUserTokenById
{
    internal sealed class GetUserTokenByTokenQueryHandler : IQueryHandler<GetUserTokenByTokenQuery, GetUserTokenByTokenQueryResponse>
    {
        private readonly IDbConnection _dbConnection;
        public GetUserTokenByTokenQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;  
        public async Task<GetUserTokenByTokenQueryResponse> Handle(GetUserTokenByTokenQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""UserTokens"" WHERE ""Id"" = @Id";
            var userTokens = await _dbConnection.QueryFirstOrDefaultAsync<GetUserTokenByTokenQueryResponse>(sql, new { request.Id });

            if (userTokens == null)
            {
                throw new UserTokenNotFoundException(request.Id);
            }
            return userTokens;
        }
    }
}
