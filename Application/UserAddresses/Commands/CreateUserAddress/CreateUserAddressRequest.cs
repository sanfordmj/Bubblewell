using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserAddresses.Commands.CreateUserAddress
{
    public sealed record CreateUserAddressRequest(Guid CompanyId, Guid UserId, DateTime? UpdatedAt, bool Deleted);
}
