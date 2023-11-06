using Application.Abstractions.Messaging;
using Application.CompanyRoutes.Queries.GetCompanyRoutesById;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.UserRoutes.Queries.GetUserRouteById
{
    internal sealed class GetUserRouteByIdQueryHandler : IQueryHandler<GetUserRouteByIdQuery, GetUserRouteByIdQueryResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetUserRouteByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetUserRouteByIdQueryResponse> Handle(GetUserRouteByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""UserRoutes"" WHERE ""Id"" = @Id";
            var userRoute = await _dbConnection.QueryFirstOrDefaultAsync<GetUserRouteByIdQueryResponse>(sql, new { request.Id });

            if (userRoute == null) {
                throw new UserRouteNotFoundException(request.Id);
            }
            return userRoute;
        }
    }
}
