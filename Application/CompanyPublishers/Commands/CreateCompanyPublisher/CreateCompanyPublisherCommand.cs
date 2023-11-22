using System;
using Application.Abstractions.Messaging;

namespace Application.CompanyPublishers.Commands.CreateCompanyPublisher
{
    public sealed record CreateCompanyPublisherCommand(Guid Id, Guid companyId, Guid publisherId, DateTime? UpdatedAt, bool Deleted) : ICommand<Guid>;
    
}
