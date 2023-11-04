using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Queries.GetRouteAddressById
{
    public sealed record GetCompanyByIdResponse(Guid Id, CompanyStatus CompanyStatus, CompanyType CompanyType, string Name, string Phone, DateTime CreateDate);
}
