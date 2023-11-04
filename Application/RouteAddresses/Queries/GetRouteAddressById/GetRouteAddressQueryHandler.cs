﻿using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.RouteAddresses.Queries.GetRouteAddressById
{
    internal sealed class GetRouteAddressQueryHandler : IQueryHandler<GetRouteAddressByIdQuery, GetRouteAddressByIdResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetRouteAddressQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetRouteAddressByIdResponse> Handle(GetRouteAddressByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""RouteAddresses"" WHERE ""Id"" = @Id";
            var route = await _dbConnection.QueryFirstOrDefaultAsync<GetRouteAddressByIdResponse>(sql, new { request.Id });

            if (route == null) {
                throw new RouteAddressNotFoundException(request.Id);
            }
            return route;
        }
    }
}
