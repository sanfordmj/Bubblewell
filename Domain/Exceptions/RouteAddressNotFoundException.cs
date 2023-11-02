using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class RouteAddressNotFoundException : NotFoundException
    {
        
        public RouteAddressNotFoundException(Guid Id):base($"The RouteAddress with the identifier {Id} was not found.") { }

    }
}
