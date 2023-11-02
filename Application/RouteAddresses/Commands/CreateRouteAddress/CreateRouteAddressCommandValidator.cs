using FluentValidation;

namespace Application.RouteAddresses.Commands.CreateRouteAddress
{
    public sealed class CreateRouteAddressCommandValidator : AbstractValidator<CreateRouteAddressCommand>
    {
        public CreateRouteAddressCommandValidator() { 
            RuleFor(x=>x.RouteId).NotEmpty();
            RuleFor(x=>x.AddressId).NotEmpty();
            RuleFor(x => x.Position).NotEmpty();
            RuleFor(x => x.ModifyDate).NotEmpty();
        }
    }
}