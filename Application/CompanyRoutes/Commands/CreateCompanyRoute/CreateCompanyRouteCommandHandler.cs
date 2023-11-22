using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.CompanyRoutes.Commands.CreateCompanyRoute
{
    internal sealed class CreateCompanyRouteCommandHandler : ICommandHandler<CreateCompanyRouteCommand, Guid>
    {
        private readonly ICompanyRouteRepository _companyRouteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyRouteCommandHandler(ICompanyRouteRepository companyRouteRepository, IUnitOfWork uow)
        {
            _companyRouteRepository = companyRouteRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateCompanyRouteCommand request, CancellationToken cancellationToken)
        {
            var companyRoute = new CompanyRoute(new Guid(), request.companyId, request.routeId, request.UpdatedAt, request.Deleted);
            _companyRouteRepository.Insert(companyRoute);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return companyRoute.Id;
        }
    }
}