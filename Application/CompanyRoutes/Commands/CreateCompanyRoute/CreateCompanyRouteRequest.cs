using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyRoutes.Commands.CreateCompanyRoute
{
    public sealed record CreateCompanyRouteRequest(Guid companyId, Guid routeId, DateTime? UpdatedAt, bool Deleted);
}
