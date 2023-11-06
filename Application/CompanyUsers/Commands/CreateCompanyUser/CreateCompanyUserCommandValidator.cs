using FluentValidation;

namespace Application.CompanyUsers.Commands.CreateCompanyUser
{
    public sealed class CreateCompanyUserCommandValidator : AbstractValidator<CreateCompanyUserCommand>
    {
        public CreateCompanyUserCommandValidator() { 
           
        }
    }
}