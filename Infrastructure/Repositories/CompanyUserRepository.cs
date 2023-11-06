using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class CompanyUserRepository : ICompanyUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyUserRepository(ApplicationDbContext dbcontext) => _dbContext = dbcontext;
        public void Insert(CompanyUser companyUser) => _dbContext.Set<CompanyUser>().Add(companyUser);
    }
}
