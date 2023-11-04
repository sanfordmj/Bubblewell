using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ICompanyUserRepository
    {
        void Insert(CompanyUser companyUser);
    }
}
