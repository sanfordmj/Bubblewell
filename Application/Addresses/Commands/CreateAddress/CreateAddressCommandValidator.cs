using FluentValidation;

namespace Application.Addresses.Commands.CreateAddress
{
    public sealed class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.street).NotEmpty();
            RuleFor(x => x.city).NotEmpty();
            RuleFor(x => x.state).NotEmpty();
            RuleFor(x => x.zip).NotEmpty();
        }
    }
}
