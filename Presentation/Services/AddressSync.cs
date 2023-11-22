
using Application.Addresses.Commands.CreateAddress;
using Domain.Entities;
using Domain.Primitives;
using Mapster;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Xml.Linq;

namespace Presentation.Services
{
    public class AddressSync : ISyncService<Address>
    {
        public event EventHandler<SyncEventArgs> TodoItemsUpdated;

        /// <summary>
        /// Retreave all changed items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<Address>> GetItemsAsync()
        {
            IEnumerable<Address> l = new List<Address>();

            CreateAddressRequest request = new CreateAddressRequest(Guid.NewGuid().ToString(), Domain.Primitives.AddressStatus.Enabled, Domain.Primitives.AddressType.Residential, "123 Pine St", "Forest Lake", "MN", "55025",
             0.0, 0.0, "Next to light", true, DateTime.UtcNow, DateTime.UtcNow, false);

            l = l.Append(request.Adapt<Address>());

            var tcs = new TaskCompletionSource<IEnumerable<Address>>();
            tcs.SetResult(l);
            return tcs.Task;

        }

        public Task RefreshItemsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mark Item as deleted
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveItemAsync(Address item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert or Update new items/changes
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task SaveItemAsync(Address item)
        {
            throw new NotImplementedException();
        }
    }
}
