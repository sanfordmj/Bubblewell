using FluentValidation;

namespace Application.Companies.Commands.CreateCompany
{
    public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator() { 
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Phone).NotEmpty();
            RuleFor(x=> x.Email).NotEmpty();
        }
    }
}