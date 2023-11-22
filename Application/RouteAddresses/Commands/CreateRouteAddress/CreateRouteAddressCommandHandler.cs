using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.RouteAddresses.Commands.CreateRouteAddress
{
    internal sealed class CreateRouteAddressCommandHandler : ICommandHandler<CreateRouteAddressCommand, Guid>
    {
        private readonly IRouteAddressRepository _routeAddressRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateRouteAddressCommandHandler(IRouteAddressRepository routeAddressRepository, IUnitOfWork uow)
        {
            _routeAddressRepository = routeAddressRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateRouteAddressCommand request, CancellationToken cancellationToken)
        {
            var routeAddress = new RouteAddress(new Guid(), request.RouteId, request.AddressId, request.Visible, request.Reviewed, request.Position, request.UpdatedAt, request.Deleted);
            _routeAddressRepository.Insert(routeAddress);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return routeAddress.Id;
        }
    }
}