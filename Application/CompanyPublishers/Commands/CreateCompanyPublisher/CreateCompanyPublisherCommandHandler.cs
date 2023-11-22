using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.CompanyPublishers.Commands.CreateCompanyPublisher
{
    internal sealed class CreateCompanyPublisherCommandHandler : ICommandHandler<CreateCompanyPublisherCommand, Guid>
    {
        private readonly ICompanyPublisherRepository _companyPublisherRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyPublisherCommandHandler(ICompanyPublisherRepository companyPublisherRepository, IUnitOfWork uow)
        {
            _companyPublisherRepository = companyPublisherRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateCompanyPublisherCommand request, CancellationToken cancellationToken)
        {
            var companyPublisher = new CompanyPublisher(new Guid(), request.companyId, request.publisherId, request.UpdatedAt, request.Deleted);
            _companyPublisherRepository.Insert(companyPublisher);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return companyPublisher.Id;
        }
    }
}