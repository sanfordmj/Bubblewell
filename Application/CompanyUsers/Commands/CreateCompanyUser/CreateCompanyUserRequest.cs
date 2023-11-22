using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyUsers.Commands.CreateCompanyUser
{
    public sealed record CreateCompanyUserRequest(Guid CompanyId, Guid UserId, DateTime? UpdatedAt, bool Deleted);
}
