using EasMe.EFCore;

namespace ECom.Infrastructure.Services
{
	public interface IAddressService : IEfEntityRepository<Address>
	{
	}
	public class AddressService : EfEntityRepositoryBase<Address,EComDbContext>, IAddressService
	{

	}

	
}
