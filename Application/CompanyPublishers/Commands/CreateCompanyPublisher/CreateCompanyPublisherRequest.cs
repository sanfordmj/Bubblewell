using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CompanyPublishers.Commands.CreateCompanyPublisher
{
    public sealed record CreateCompanyPublisherRequest(Guid companyId, Guid publisherId);
}
