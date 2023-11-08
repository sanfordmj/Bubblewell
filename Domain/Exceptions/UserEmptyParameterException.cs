using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserEmptyParameterException : EmptyParameterException
    {
        public UserEmptyParameterException(string param) : base($"The User filter provided is not valid '{param}'.") { }
    }
}
