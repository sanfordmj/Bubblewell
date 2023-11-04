using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ICompanyRepository
    {
        void Insert(Company company);
    }
}
