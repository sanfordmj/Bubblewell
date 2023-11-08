using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Base
{
    public abstract class EmptyParameterException : Exception
    {
        protected EmptyParameterException(string message): base(message) { } 
    }
}
