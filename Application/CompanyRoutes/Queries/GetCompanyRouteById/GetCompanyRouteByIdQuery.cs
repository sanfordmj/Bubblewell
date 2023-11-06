using Application.Abstractions.Messaging;
using Application.CompanyRoutes.Queries.GetCompanyRoutesById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyRoutes.Queries.GetCompanyRouteById
{
    public sealed record GetCompanyRouteByIdQuery(Guid Id) : IQuery<GetCompanyRouteByIdQueryResponse>;
}
