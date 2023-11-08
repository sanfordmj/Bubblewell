using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserAddressNotFoundException : NotFoundException
    {
        public UserAddressNotFoundException(Guid Id):base($"The User Address with the identifier {Id} was not found.") { }
    }
}
