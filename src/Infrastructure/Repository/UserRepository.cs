namespace ECom.Infrastructure.Repository;

public class UserRepository : GenericRepository<User,EComDbContext>
{
    public UserRepository(EComDbContext context) : base(context)
    {
    }
}