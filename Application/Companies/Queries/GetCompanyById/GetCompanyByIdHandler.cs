using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.Companies.Queries.GetRouteAddressById
{
    internal sealed class GetCompanyByIdHandler : IQueryHandler<GetRouteAddressByIdQuery, RouteAddressResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetRouteAddressQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<RouteAddressResponse> Handle(GetRouteAddressByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""RouteAddresses"" WHERE ""Id"" = @Id";
            var route = await _dbConnection.QueryFirstOrDefaultAsync<RouteAddressResponse>(sql, new { request.Id });

            if (route == null) {
                throw new RouteAddressNotFoundException(request.Id);
            }
            return route;
        }
    }
}
