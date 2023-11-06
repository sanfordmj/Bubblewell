using Application.Abstractions.Messaging;
using Application.CompanyRoutes.Queries.GetCompanyRoutesById;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.CompanyUsers.Queries.GetCompanyUserById
{
    internal sealed class GetCompanyUserByIdQueryHandler : IQueryHandler<GetCompanyUserByIdQuery, GetCompanyUserByIdQueryResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetCompanyUserByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetCompanyUserByIdQueryResponse> Handle(GetCompanyUserByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""CompanyUsers"" WHERE ""Id"" = @Id";
            var companyUser = await _dbConnection.QueryFirstOrDefaultAsync<GetCompanyUserByIdQueryResponse>(sql, new { request.Id });

            if (companyUser == null) {
                throw new CompanyUserNotFoundException(request.Id);
            }
            return companyUser;
        }
    }
}
