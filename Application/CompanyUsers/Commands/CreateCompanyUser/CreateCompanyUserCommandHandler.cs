using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.CompanyUsers.Commands.CreateCompanyUser
{
    internal sealed class CreateCompanyUserCommandHandler : ICommandHandler<CreateCompanyUserCommand, Guid>
    {
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyUserCommandHandler(ICompanyUserRepository companyUserRepository, IUnitOfWork uow)
        {
            _companyUserRepository = companyUserRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateCompanyUserCommand request, CancellationToken cancellationToken)
        {
            var companyUser = new CompanyUser(new Guid(), request.companyId, request.userId);
            _companyUserRepository.Insert(companyUser);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return companyUser.Id;
        }
    }
}