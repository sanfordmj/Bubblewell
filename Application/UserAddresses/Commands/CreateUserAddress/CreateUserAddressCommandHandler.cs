using Application.Abstractions.Messaging;
using Application.UserAddresses.Commands.CreateUserAddress;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.UserAddresses.Commands.CreateUserAddress
{
    internal sealed class CreateUserAddressCommandHandler : ICommandHandler<CreateUserAddressCommand, Guid>
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserAddressCommandHandler(IUserAddressRepository userAddressRepository, IUnitOfWork uow)
        {
            _userAddressRepository = userAddressRepository;
            _unitOfWork = uow;
        }
        public async Task<Guid> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = new UserAddress(new Guid(), request.UserId, request.AddressId, request.Visible, request.ModifyDate);
            _userAddressRepository.Insert(userAddress);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return userAddress.Id;
        }
    }
}