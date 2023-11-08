using Application.Routes.Commands.CreateRoute;
using Application.UserTokens.Commands.CreateUserToken;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Commands.CreateUserToken
{
    public sealed class CreateUserTokenCommandValidator : AbstractValidator<CreateUserTokenCommand>
    {
        public CreateUserTokenCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Token).NotEmpty();
            RuleFor(x => x.IsRevoked).NotNull();
            RuleFor(x => x.IsExpired).NotNull();
            RuleFor(x => x.CreateDate).NotNull();
            RuleFor(x => x.ExpireDate).NotNull();
        }
    }
}