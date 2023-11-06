using System;
using Application.Abstractions.Messaging;
using Domain.Primitives;

namespace Application.Companies.Commands.CreateCompany
{
    public sealed record CreateCompanyCommand(Guid Id, CompanyStatus CompanyStatus, CompanyType CompanyType, string Name, string Phone, string Email, DateTime CreateDate) : ICommand<Guid>;
    
}
