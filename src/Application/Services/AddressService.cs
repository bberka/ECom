using EasMe.EFCore;

namespace ECom.Application.Services
{
	public interface IAddressService : IEfEntityRepository<Address>
	{
	}
	public class AddressService : EfEntityRepositoryBase<Address,EComDbContext>, IAddressService
	{

	}

	
}
