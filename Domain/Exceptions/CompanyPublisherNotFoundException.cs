using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class CompanyPublisherNotFoundException : NotFoundException
    {
        
        public CompanyPublisherNotFoundException(Guid Id):base($"The Company Publisher with the identifier {Id} was not found.") { }

    }
}
