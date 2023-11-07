using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Extensions
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            if (dbContext.Set<User>().Any()) return;

            //new User(new Guid(), request.UserStatus, request.UserType, request.UserName, request.Hash, request.FirstName, request.LastName, request.Email, request.CreateDate);

            var users = new User[]
            {
                new User(new Guid(), UserStatus.Enabled, UserType.Root, "root", "WVYm5WI5P5xgDDUM4C/UGut2THB9lS9A4QOF4PVlEfg=", "root", "root", "admin@bubblewell.com", DateTime.Now)
            };
            //add other users
        

            foreach (var user in users)
                dbContext.Set<User>().Add(user);

            dbContext.SaveChanges();
        }
    }
}
