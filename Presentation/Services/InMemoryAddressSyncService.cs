using Presentation.TableEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class InMemoryAddressSyncService : IAddressSyncService
    {
        private readonly List<AddressSync> _items = new List<AddressSync>();
        public event EventHandler<AddressSyncEventArgs> TodoItemsUpdated;

        public Task<IEnumerable<AddressSync>> GetItemsAsync() => Task.FromResult((IEnumerable<AddressSync>)_items);

        public Task RefreshItemsAsync() => Task.CompletedTask;

        public Task RemoveItemAsync(AddressSync item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.Id != null)
            {
                var itemToRemove = _items.SingleOrDefault(m => m.Id == item.Id);
                if (itemToRemove != null)
                {
                    _items.Remove(itemToRemove);
                    TodoItemsUpdated?.Invoke(this, new AddressSyncEventArgs(AddressSyncEventArgs.ListAction.Delete, itemToRemove));
                }
            }

            return Task.CompletedTask;
        }

        public Task SaveItemAsync(AddressSync item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Version = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString());
            item.UpdatedAt = DateTimeOffset.UtcNow;

            if (item.Id == null)
            {
                item.Id = Guid.NewGuid().ToString();
                _items.Add(item);
                TodoItemsUpdated?.Invoke(this, new AddressSyncEventArgs(AddressSyncEventArgs.ListAction.Add, item));
            }
            else
            {
                var itemToReplace = _items.SingleOrDefault(m => m.Id == item.Id);
                if (itemToReplace != null)
                {
                    var idx = _items.IndexOf(itemToReplace);
                    _items[idx] = item;
                    TodoItemsUpdated?.Invoke(this, new AddressSyncEventArgs(AddressSyncEventArgs.ListAction.Update, item));
                }
            }

            return Task.CompletedTask;
        }
    }
}
