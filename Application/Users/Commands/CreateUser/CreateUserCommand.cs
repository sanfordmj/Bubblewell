using Application.Abstractions.Messaging;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(Guid Id, UserStatus UserStatus, UserType UserType, string UserName, string Password, string FirstName, string LastName, string Email, DateTime CreateDate) : ICommand<Guid>;
}
