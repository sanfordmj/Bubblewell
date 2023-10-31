

using FluentValidation;

namespace Application.Routes.Commands.CreateRoute
{
    public sealed class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
    {
        public CreateRouteCommandValidator() { 
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.CreateDate).NotEmpty();
        }
    }
}
