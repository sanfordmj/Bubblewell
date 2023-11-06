using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class UserTokenRepository : IUserTokenRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserTokenRepository(ApplicationDbContext context) => _dbContext = context;
        public void Insert(UserToken userToken) => _dbContext.Set<UserToken>().Add(userToken);
    }
}
