using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    internal class RouteSync : ISyncService<Route>
    {
        public event EventHandler<SyncEventArgs> TodoItemsUpdated;

        public Task<IEnumerable<Route>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RefreshItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemAsync(Route item)
        {
            throw new NotImplementedException();
        }

        public Task SaveItemAsync(Route item)
        {
            throw new NotImplementedException();
        }
    }
}
