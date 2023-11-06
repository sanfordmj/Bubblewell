using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class CompanyRouteNotFoundException : NotFoundException
    {
        
        public CompanyRouteNotFoundException(Guid Id):base($"The Company Route with the identifier {Id} was not found.") { }

    }
}
