using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Routes.Commands.CreateRoute
{
    internal sealed class CreateRouteCommandHandler : ICommandHandler<CreateRouteCommand, Guid>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateRouteCommandHandler(IRouteRepository routeRepository, IUnitOfWork uow)
        {
            _routeRepository = routeRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            var route = new Route(new Guid(), request.Name, request.CreateDate);
            _routeRepository.Insert(route);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return route.Id;
        }

    }
}
