using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string Hash) : base($"The User with the hash {Hash} was not found.") { }
        public UserNotFoundException(Guid Id):base($"The User with the identifier {Id} was not found.") { }

    }
}
