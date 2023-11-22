using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyPublishers.Queries.GetCompanyPublisherById
{
    public sealed record GetCompanyPublisherByIdQueryResponse(Guid Id, Guid CompanyId, Guid PublisherId, DateTime? UpdatedAt, bool Deleted);
}
