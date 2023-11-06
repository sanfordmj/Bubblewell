using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class UserRouteRepository : IUserRouteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRouteRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public void Insert(UserRoute userRoute) => _dbContext.Set<UserRoute>().Add(userRoute);
    }
}
