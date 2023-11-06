using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Commands.CreateCompany
{
    public sealed record CreateCompanyRequest(CompanyStatus CompanyStatus, CompanyType CompanyType, string Name, string Phone, string Email, DateTime CreateDate);
}
