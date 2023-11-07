using Domain.Primitives;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateUserRequest(UserStatus UserStatus, UserType UserType, string UserName, string Hash, string FirstName, string LastName, string Email, DateTime CreateDate);
}
