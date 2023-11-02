using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class RouteAddressRepository : IRouteAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RouteAddressRepository(ApplicationDbContext dbcontext) => _dbContext = dbcontext;
        public void Insert(RouteAddress routeAddress) => _dbContext.Set<RouteAddress>().Add(routeAddress);
    }
}
