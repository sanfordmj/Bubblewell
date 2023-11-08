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
                new User(new Guid(), UserStatus.Enabled, UserType.Root, "root", "AQAAAAIAAYagAAAAECzB1628XhTIV7xMaeLkMNVptC+zhmw/eAACvZdCeJVv8Yz4lfqcrVw+AkVZhyXH/g==", "root", "root", "651-808-5265", "root@bubblewell.com", DateTime.Now)
            };
            //add other users
        

            foreach (var user in users)
                dbContext.Set<User>().Add(user);

            dbContext.SaveChanges();
        }
    }
}
