using FluentValidation;

namespace Application.Addresses.Commands.CreateAddress
{
    public sealed class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.Zip).NotEmpty();
            RuleFor(x => x.Lat).NotEmpty();
            RuleFor(x => x.Lng).NotEmpty();
            RuleFor(x => x.Bagged).NotEmpty();
            RuleFor(x => x.CreateDate).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
            RuleFor(x => x.Deleted).NotEmpty();
        }
    }
}
