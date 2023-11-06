using Application.Abstractions.Messaging;
using Application.CompanyRoutes.Queries.GetCompanyRoutesById;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.CompanyRoutes.Queries.GetCompanyRouteById
{
    internal sealed class GetCompanyRouteByIdQueryHandler : IQueryHandler<GetCompanyRouteByIdQuery, GetCompanyRouteByIdQueryResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetCompanyRouteByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetCompanyRouteByIdQueryResponse> Handle(GetCompanyRouteByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""CompanyRoutes"" WHERE ""Id"" = @Id";
            var companyRoute = await _dbConnection.QueryFirstOrDefaultAsync<GetCompanyRouteByIdQueryResponse>(sql, new { request.Id });

            if (companyRoute == null) {
                throw new CompanyRouteNotFoundException(request.Id);
            }
            return companyRoute;
        }
    }
}
