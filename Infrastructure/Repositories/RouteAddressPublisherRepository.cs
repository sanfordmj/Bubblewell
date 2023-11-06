using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class RouteAddressPublisherRepository : IRouteAddressPublisherRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RouteAddressPublisherRepository(ApplicationDbContext dbcontext) => _dbContext = dbcontext;
        public void Insert(RouteAddressPublisher routeAddressPublisher) => _dbContext.Set<RouteAddressPublisher>().Add(routeAddressPublisher);
    }
}
