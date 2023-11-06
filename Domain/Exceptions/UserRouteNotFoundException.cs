using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserRouteNotFoundException : NotFoundException
    {
        
        public UserRouteNotFoundException(Guid Id):base($"The User Route with the identifier {Id} was not found.") { }

    }
}
