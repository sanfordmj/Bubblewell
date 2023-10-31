using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class RouteRepository : IRouteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RouteRepository(ApplicationDbContext context) => _dbContext = context;
        public void Insert(Route route) => _dbContext.Set<Route>().Add(route);
    }
}
