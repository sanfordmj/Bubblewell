using Application.Abstractions.Messaging;
using Application.UserAddresses.Commands.CreateUserAddress;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.UserRoutes.Commands.CreateUserRoute
{
    internal sealed class CreateUserRouteCommandHandler : ICommandHandler<CreateUserRouteCommand, Guid>
    {
        private readonly IUserRouteRepository _userRouteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserRouteCommandHandler(IUserRouteRepository userRouteRepository, IUnitOfWork uow)
        {
            _userRouteRepository = userRouteRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateUserRouteCommand request, CancellationToken cancellationToken)
        {
            var userRoute = new UserRoute(new Guid(), request.UserId, request.RouteId, request.UpdatedAt, request.Deleted);
            _userRouteRepository.Insert(userRoute);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return userRoute.Id;
        }
    }
}