﻿using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class CompanyNotFoundException : NotFoundException
    {
        
        public CompanyNotFoundException(Guid Id):base($"The Company with the identifier {Id} was not found.") { }

    }
}
