using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class CompanyUserNotFoundException : NotFoundException
    {
        
        public CompanyUserNotFoundException(Guid Id):base($"The Company User with the identifier {Id} was not found.") { }

    }
}
