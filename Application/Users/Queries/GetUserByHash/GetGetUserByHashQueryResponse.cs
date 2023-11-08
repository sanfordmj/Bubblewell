using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByHash
{
    public sealed record GetUserByHashQueryResponse(Guid Id, UserStatus UserStatus, UserType UserType, string Hash, string FirstName, string LastName, string CellPhone, string Email, DateTime CreateDate);
}
