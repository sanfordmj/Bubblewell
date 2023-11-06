using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Commands.CreateUserToken
{
    public sealed record CreateUserTokenRequest(string UserName, string Password);
}
