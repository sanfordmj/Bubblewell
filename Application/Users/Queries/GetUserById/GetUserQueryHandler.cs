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

namespace Application.Users.Queries.GetUserById
{
    internal sealed class GetUserQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private readonly IDbConnection _dbConnection;
        public GetUserQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;  
        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""Users"" WHERE ""Id"" = @Id";
            var user = await _dbConnection.QueryFirstOrDefaultAsync<GetUserByIdQueryResponse>(sql, new { request.Id });

            if (user == null)
            {
                throw new UserNotFoundException(request.Id);
            }
            return user;
        }
    }
}
