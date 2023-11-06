using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class CompanyRouteRepository : ICompanyRouteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyRouteRepository(ApplicationDbContext dbcontext) => _dbContext = dbcontext;
        public void Insert(CompanyRoute companyRoute) => _dbContext.Set<CompanyRoute>().Add(companyRoute);
    }
}
