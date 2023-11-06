using FluentValidation;

namespace Application.UserAddresses.Commands.CreateUserAddress
{
    public sealed class CreateUserAddressCommandValidator : AbstractValidator<CreateUserAddressCommand>
    {
        public CreateUserAddressCommandValidator() { 
           
        }
    }
}