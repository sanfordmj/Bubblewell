using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Queries.GetRouteAddressById
{
    public sealed record GetCompanyByIdQueryResponse(Guid Id, CompanyStatus CompanyStatus, CompanyType CompanyType, string Name, string Phone, DateTime CreateDate, DateTime? UpdatedAt, bool Deleted);
}
