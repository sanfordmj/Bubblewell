using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.Routes.Queries.GetRouteById
{
    internal sealed class GetRouteQueryHandler : IQueryHandler<GetRouteByIdQuery, RouteResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetRouteQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<RouteResponse> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""Routes"" WHERE ""Id"" = @Id";
            var route = await _dbConnection.QueryFirstOrDefaultAsync<RouteResponse>(sql, new { request.Id });

            if (route == null) {
                throw new RouteNotFoundException(request.Id);
            }
            return route;
        }
    }
}
