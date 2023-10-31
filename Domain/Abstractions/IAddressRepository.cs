using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IAddressRepository
    {
        void Insert(Address address);
    }
}
