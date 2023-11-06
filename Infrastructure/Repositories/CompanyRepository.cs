using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public void Insert(Company company) => _dbContext.Set<Company>().Add(company);
    }
}
