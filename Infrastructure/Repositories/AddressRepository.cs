using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AddressRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public void Insert(Address address) => _dbContext.Set<Address>().Add(address);
    }
}
