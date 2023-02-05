using EasMe.EFCore;
using System.Collections.Specialized;

namespace ECom.Application.Services
{

	public class AddressService : IAddressService
	{
		private readonly IEfEntityRepository<Address> _addressRepo;
		private readonly IUserService _userService;

		public AddressService(
			IEfEntityRepository<Address> addressRepo,
			IUserService userService)
		{
			this._addressRepo = addressRepo;
			this._userService = userService;
		}

		
		public Result DeleteAddress(int userId, int id)
		{
			var data = _addressRepo.Find(id);
			if (data is null) throw new NotExistException(nameof(Address));
			if (data.DeleteDate is not null) throw new AlreadyDeletedException(nameof(Address));
            if (data.UserId != userId) throw new NotAuthorizedException(AuthType.User);
			data.DeleteDate = DateTime.Now;
			_addressRepo.Update(data);	
			return Result.Success("Updated",nameof(Address));
		}

	
		public List<Address> GetUserAddresses(int userId)
		{
			_userService.CheckExistsOrThrow(userId);
			var list = _addressRepo.GetList(x => x.UserId == userId && x.DeleteDate != null);
			return list;
		}

		public Result UpdateAddress(Address address)
		{
			var res = _addressRepo.Update(address);
			if (!res) throw new DbInternalException(nameof(UpdateAddress));
			return Result.Success("Updated", "Address");
		}

		public Result AddAddress(Address address)
		{
			var res = _addressRepo.Add(address);
            if (!res) throw new DbInternalException(nameof(AddAddress));
			return Result.Success("Added", "Address");
		}

		
	}


}
