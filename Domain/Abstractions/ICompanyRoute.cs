using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ICompanyRouteRepository
    {
        void Insert(CompanyRoute companyRoute);
    }
}
