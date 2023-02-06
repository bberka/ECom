using EasMe.EFCore;
using System.Collections.Specialized;
using System.Runtime.Loader;

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
			if (data is null)
			{
                return Result.Warn(1, ErrorCode.NotFound);
            }
            if (data.UserId != userId)
			{
                throw new NotAuthorizedException(AuthType.User);
            }
            if (data.DeleteDate.HasValue)
			{
                return Result.Warn(2, ErrorCode.AlreadyDeleted);
            }
			data.DeleteDate = DateTime.Now;
			var res = _addressRepo.Update(data);	
			if(!res)
			{
                return Result.DbInternal(3);
            }
			return Result.Success();
		}

		public List<Address> GetUserAddresses(int userId)
		{
			return _addressRepo.GetList(x => x.UserId == userId && x.DeleteDate != null);
		}

		public Result UpdateAddress(int userId,Address data)
		{
			var address = _addressRepo.Find(data.Id);
			if(address is null) 
			{
                return Result.Error(1, ErrorCode.NotFound);
            }
			if (address.UserId != userId)
			{
                throw new NotAuthorizedException(AuthType.User);
            }
            if (data.DeleteDate.HasValue)
			{
                return Result.Error(2, ErrorCode.Deleted);
            }
            var res = _addressRepo.Update(data);
            if (!res) 
			{
                return Result.DbInternal(3);
            }
            return Result.Success();
		}

		public Result AddAddress(int userId,Address address)
		{
			var res = _addressRepo.Add(address);
			if (!res)
			{
                return Result.DbInternal(1);
            }
			return Result.Success();
		}

		
	}


}
