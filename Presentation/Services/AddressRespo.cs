using Application.Addresses.Commands.CreateAddress;
using Microsoft.AspNetCore.Datasync;
using Presentation.TableEntities;
using MediatR;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Presentation.Services
{
    public class AddressRespo : IRepository<AddressSync>
    {
        ISender Sender;
        
        public AddressRespo(IMediator sender)
        {
            Sender = sender;
        }
        public IQueryable<AddressSync> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AddressSync entity, CancellationToken token = default)
        {
            CreateAddressRequest request = new CreateAddressRequest(entity.AddressStatus, entity.AddressType, entity.Street, entity.City, entity.State, entity.Zip,
                entity.LAT, entity.LNG, entity.Comments, entity.Bagged, entity.CreateDate, entity.Version ?? new Guid().ToByteArray(), entity.UpdatedAt, entity.Deleted);

            CancellationToken cancellationToken = new CancellationToken();


            var addressCommand = request.Adapt<CreateAddressCommand>();
            var addressId = await Sender.Send(addressCommand, cancellationToken);
            entity.Id = addressId.ToString();

            var tcs = new TaskCompletionSource<AddressSync>();
            tcs.SetResult(entity);

            return;
        }


        public Task DeleteAsync(string id, byte[] version = null, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<AddressSync> ReadAsync(string id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceAsync(AddressSync entity, byte[] version = null, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
