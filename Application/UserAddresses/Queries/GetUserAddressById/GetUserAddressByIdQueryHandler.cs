using Application.Abstractions.Messaging;
using Application.CompanyRoutes.Queries.GetCompanyRoutesById;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.UserAddresses.Queries.GetUserAddressById
{
    internal sealed class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, GetUserAddressByIdQueryResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetUserAddressByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetUserAddressByIdQueryResponse> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""UserAddresses"" WHERE ""Id"" = @Id";
            var userAddress = await _dbConnection.QueryFirstOrDefaultAsync<GetUserAddressByIdQueryResponse>(sql, new { request.Id });

            if (userAddress == null) {
                throw new UserAddressNotFoundException(request.Id);
            }
            return userAddress;
        }
    }
}
