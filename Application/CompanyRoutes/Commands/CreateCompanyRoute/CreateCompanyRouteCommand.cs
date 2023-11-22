using System;
using Application.Abstractions.Messaging;

namespace Application.CompanyRoutes.Commands.CreateCompanyRoute
{
    public sealed record CreateCompanyRouteCommand(Guid Id, Guid companyId, Guid routeId, DateTime? UpdatedAt, bool Deleted) : ICommand<Guid>;
    
}
