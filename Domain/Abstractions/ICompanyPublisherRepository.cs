using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ICompanyPublisherRepository
    {
        void Insert(CompanyPublisher companyPublisher);
    }
}
