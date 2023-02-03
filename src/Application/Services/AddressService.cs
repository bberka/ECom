using EasMe.EFCore;
using System.Collections.Specialized;

namespace ECom.Application.Services
{
	public interface IAddressService 
	{
		public List<Address> GetUserAddresses(int userId);
		public Result UpdateAddress(Address address);
		public Result DeleteAddress(int userId,int id);
		public Result AddAddress(Address address);


	}
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
			if (data is null) return Result.Error(1, ErrCode.NotFound, nameof(Address));
			if (data.DeleteDate is not null) return Result.Error(2, ErrCode.AlreadyDeleted,nameof(Address));
			if (data.UserId != userId) throw new NotAuthorizedException();
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
			if (!res) Result.Error(1, ErrCode.DbErrorInternal);
			return Result.Success("Updated", "Address");
		}

		public Result AddAddress(Address address)
		{
			var res = _addressRepo.Add(address);
			if (!res) Result.Error(1, ErrCode.DbErrorInternal);
			return Result.Success("Added", "Address");
		}

		
	}


}
