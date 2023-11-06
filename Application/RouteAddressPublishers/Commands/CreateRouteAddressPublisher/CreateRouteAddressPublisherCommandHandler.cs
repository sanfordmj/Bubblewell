using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.RouteAddressPublishers.Commands.CreateRouteAddressPublisher
{
    internal sealed class CreateRouteAddressPublisherCommandHandler : ICommandHandler<CreateRouteAddressPublisherCommand, Guid>
    {
        private readonly IRouteAddressPublisherRepository _routeAddressPublisherRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateRouteAddressPublisherCommandHandler(IRouteAddressPublisherRepository routeAddressPublisherRepository, IUnitOfWork uow)
        {
            _routeAddressPublisherRepository = routeAddressPublisherRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateRouteAddressPublisherCommand request, CancellationToken cancellationToken)
        {
            var routeAddressPublisher = new RouteAddressPublisher(new Guid(), request.RouteAddressId, request.PublisherId);
            _routeAddressPublisherRepository.Insert(routeAddressPublisher);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return routeAddressPublisher.Id;
        }
    }
}