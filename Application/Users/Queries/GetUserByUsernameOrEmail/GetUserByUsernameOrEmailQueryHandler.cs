using Application.Abstractions.Messaging;
using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    internal sealed class GetUserByUsernameOrEmailQueryHandler : IQueryHandler<GetUserByUsernameOrEmailQuery, GetUserByUsernameOrEmailQueryResponse>
    {
        private readonly IDbConnection _dbConnection;
        public GetUserByUsernameOrEmailQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;  
        public async Task<GetUserByUsernameOrEmailQueryResponse> Handle(GetUserByUsernameOrEmailQuery request, CancellationToken cancellationToken)
        {
         
            if(string.IsNullOrWhiteSpace(request.filter))
                throw new UserEmptyParameterException(request.filter);

            const string sql = @"SELECT * FROM ""Users"" WHERE ""UserName"" = @filter OR ""Email"" = @filter";
            var user = await _dbConnection.QueryFirstOrDefaultAsync<GetUserByUsernameOrEmailQueryResponse>(sql, new { request.filter });

            if (user == null)
                throw new UserNotFoundException(request.filter);

            return user;
        }
    }
}
