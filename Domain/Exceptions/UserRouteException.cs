using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserRouteException : NotFoundException
    {
        
        public UserRouteException(Guid Id):base($"The User Route with the identifier {Id} was not found.") { }

    }
}
