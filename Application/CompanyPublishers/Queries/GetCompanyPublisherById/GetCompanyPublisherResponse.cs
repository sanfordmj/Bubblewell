using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyPublishers.Queries.GetCompanyPublisherById
{
    public sealed record GetCompanyPublisherResponse(Guid Id, Guid CompanyId, Guid PublisherId);
}
