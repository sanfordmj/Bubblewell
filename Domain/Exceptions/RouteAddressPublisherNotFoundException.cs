﻿using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class RouteAddressPublisherNotFoundException : NotFoundException
    {
        
        public RouteAddressPublisherNotFoundException(Guid Id):base($"The RouteAddress Publisher with the identifier {Id} was not found.") { }

    }
}
