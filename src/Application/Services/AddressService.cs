using EasMe.EFCore;

namespace ECom.Application.Services
{
	public interface IAddressService 
	{
	}
	public class AddressService : EfEntityRepositoryBase<Address,EComDbContext>, IAddressService
	{

	}

	
}
