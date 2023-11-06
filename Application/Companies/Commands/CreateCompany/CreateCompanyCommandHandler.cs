using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Companies.Commands.CreateCompany
{
    internal sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, Guid>
    {
        private readonly ICompanyRepository _routeCompanyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork uow)
        {
            _routeCompanyRepository = companyRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(new Guid(), request.CompanyStatus, request.CompanyType, request.Name, request.Phone, request.Email, request.CreateDate);
            _routeCompanyRepository.Insert(company);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return company.Id;
        }
    }
}