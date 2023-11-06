using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyRoutes.Queries.GetCompanyRoutesById
{
    public sealed record GetCompanyRouteByIdQueryResponse(Guid Id, Guid CompanyId, Guid RouteId);
}
