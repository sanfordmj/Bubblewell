using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PublisherRepository(ApplicationDbContext dbcontext) => _dbContext = dbcontext;
        public void Insert(Publisher publisher) => _dbContext.Set<Publisher>().Add(publisher);
    }
}
