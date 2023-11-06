using Application.Abstractions.Messaging;
using Application.Companies.Queries.GetCompanyById;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.Companies.Queries.GetRouteAddressById
{
    internal sealed class GetCompanyByIdHandler : IQueryHandler<GetCompanyByIdQuery, GetCompanyByIdQueryResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetCompanyByIdHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""Companies"" WHERE ""Id"" = @Id";
            var route = await _dbConnection.QueryFirstOrDefaultAsync<GetCompanyByIdQueryResponse>(sql, new { request.Id });

            if (route == null) {
                throw new CompanyNotFoundException(request.Id);
            }
            return route;
        }
    }
}
