using Application.Abstractions.Messaging;

namespace Application.Routes.Queries.GetRouteById
{
    public sealed record GetRouteByIdQuery(Guid Id) : IQuery<GetRouteByIdQueryResponse>;
}
