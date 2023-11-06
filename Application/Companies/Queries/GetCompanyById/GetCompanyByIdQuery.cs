using Application.Abstractions.Messaging;
using Application.Companies.Queries.GetRouteAddressById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Queries.GetCompanyById
{
    public sealed record GetCompanyByIdQuery(Guid Id) : IQuery<GetCompanyByIdQueryResponse>;
}
