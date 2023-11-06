using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class UserAddressRepository : IUserAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserAddressRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public void Insert(UserAddress userAddress) => _dbContext.Set<UserAddress>().Add(userAddress);
    }
}
