using System;
using Application.Abstractions.Messaging;

namespace Application.CompanyUsers.Commands.CreateCompanyUser
{
    public sealed record CreateCompanyUserCommand(Guid Id, Guid companyId, Guid userId) : ICommand<Guid>;
    
}
