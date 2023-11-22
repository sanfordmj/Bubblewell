using Application.Abstractions.Messaging;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(Guid Id, UserStatus UserStatus, UserType UserType, string UserName,  string Hash, string FirstName, string LastName, string CellPhone, string Email, DateTime? CreateDate, DateTime? UpdatedAt, bool Deleted) : ICommand<Guid>;
}
