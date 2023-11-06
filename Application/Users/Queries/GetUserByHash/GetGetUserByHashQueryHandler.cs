using Application.Abstractions.Messaging;
using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByHash
{
    internal sealed class GetUserByHashQueryHandler : IQueryHandler<GetUserByHashQuery, GetUserByHashQueryResponse>
    {
        private readonly IDbConnection _dbConnection;
        public GetUserByHashQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;  
        public async Task<GetUserByHashQueryResponse> Handle(GetUserByHashQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""Users"" WHERE ""Hash"" = @Hash";
            var user = await _dbConnection.QueryFirstOrDefaultAsync<GetUserByHashQueryResponse>(sql, new { request.Hash });

            if (user == null)
            {
                throw new UserNotFoundException(request.Hash);
            }
            return user;
        }
    }
}
