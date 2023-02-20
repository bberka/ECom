using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class AddressRepository : GenericRepository<Address,EComDbContext>
{
    public AddressRepository(EComDbContext context) : base(context)
    {
    }
}