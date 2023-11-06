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
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
            RuleFor(x => x.IsRevoked).NotEmpty();
            RuleFor(x => x.IsExpired).NotEmpty();
            RuleFor(x => x.CreateDate).NotEmpty();
            RuleFor(x => x.ExpireDate).NotEmpty();
        }
    }
}