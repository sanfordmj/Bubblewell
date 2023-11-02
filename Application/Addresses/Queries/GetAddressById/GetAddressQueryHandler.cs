using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.Addresses.Queries.GetAddressById
{
    internal sealed class GetAddressQueryHandler : IQueryHandler<GetAddressByIdQuery, AddressResponse>
    {
        private readonly IDbConnection _dbConnection;
        public GetAddressQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        public async Task<AddressResponse> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""Addresses"" WHERE ""Id"" = @Id";
            var address = await _dbConnection.QueryFirstOrDefaultAsync<AddressResponse>(sql, new { request.Id });

            if (address == null)
            {
                throw new AddressNotFoundException(request.Id);
            }
            return address;
        }
    }
}
