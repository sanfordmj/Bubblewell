using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;
using System.Data;

namespace Application.RouteAddressPublishers.Queries.GetRouteAddressPublisherById
{
    internal sealed class GetRouteAddressPublisherByIdQueryHandler : IQueryHandler<GetRouteAddressPublisherByIdQuery, GetRouteAddressPublisherByIdQueryResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetRouteAddressPublisherByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        
        public async Task<GetRouteAddressPublisherByIdQueryResponse> Handle(GetRouteAddressPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""RouteAddressPublishers"" WHERE ""Id"" = @Id";
            var routeAddressPublisher = await _dbConnection.QueryFirstOrDefaultAsync<GetRouteAddressPublisherByIdQueryResponse>(sql, new { request.Id });

            if (routeAddressPublisher == null) {
                throw new RouteAddressPublisherNotFoundException(request.Id);
            }
            return routeAddressPublisher;
        }
    }
}
