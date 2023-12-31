﻿using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Commands.CreateAddress
{
    internal sealed class CreateAdressCommandHandler : ICommandHandler<CreateAddressCommand, Guid>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateAdressCommandHandler(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(string.IsNullOrEmpty(request.SyncId) ? new Guid() : new Guid(request.SyncId), request.AddressStatus, request.AddressType, request.Street, request.City, request.State, request.Zip, request.Lat,
            request.Lng, request.Comments, request.Bagged, request.CreateDate, request.UpdatedAt, request.Deleted);
            _addressRepository.Insert(address);
            await _unitOfWork.SaveChangesAsync();
            return address.Id;
        }
    }
}
