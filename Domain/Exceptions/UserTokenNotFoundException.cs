using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserTokenNotFoundException : NotFoundException
    {
        
        public UserTokenNotFoundException(Guid Id):base($"The User Token with the identifier {Id} was not found.") { }

    }
}
