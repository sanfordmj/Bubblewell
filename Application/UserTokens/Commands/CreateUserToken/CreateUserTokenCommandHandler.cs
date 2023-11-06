using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTokens.Commands.CreateUserToken
{
    internal sealed class CreateUserTokenCommandHandler : ICommandHandler<CreateUserTokenCommand, Guid>
    {
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserTokenCommandHandler(IUserTokenRepository userTokenRepository, IUnitOfWork unitOfWork)
        {
            _userTokenRepository = userTokenRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
        {

            var userToken = new UserToken(new Guid(), request.UserId, request.Token, request.CreateDate, request.ExpireDate, request.IsExpired, request.IsRevoked);
            _userTokenRepository.Insert(userToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return userToken.Id;
        }
    }
}
