using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Routes.Commands.CreateRoute
{
    public sealed record CreateRouteRequest(string Name, DateTime CreateDate);
}
