using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.CompanyPublishers.Queries.GetCompanyPublisherById
{
    internal sealed class GetCompanyPublisherByIdQueryHandler : IQueryHandler<GetCompanyPublisherByIdQuery, GetCompanyPublisherResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetCompanyPublisherByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetCompanyPublisherResponse> Handle(GetCompanyPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""CompanyPublishers"" WHERE ""Id"" = @Id";
            var route = await _dbConnection.QueryFirstOrDefaultAsync<GetCompanyPublisherResponse>(sql, new { request.Id });

            if (route == null) {
                throw new CompanyPublisherNotFoundException(request.Id);
            }
            return route;
        }
    }
}
