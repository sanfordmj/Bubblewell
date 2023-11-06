using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class CompanyPublisherRepository : ICompanyPublisherRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyPublisherRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public void Insert(CompanyPublisher companyPublisher) => _dbContext.Set<CompanyPublisher>().Add(companyPublisher);
    }
}
