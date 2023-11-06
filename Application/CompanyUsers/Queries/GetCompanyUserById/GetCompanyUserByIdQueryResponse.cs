using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyUsers.Queries.GetCompanyUserById
{
    public sealed record GetCompanyUserByIdQueryResponse(Guid Id, Guid CompanyId, Guid UserId);
}
