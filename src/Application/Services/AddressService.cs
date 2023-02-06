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
            var data = GetAddress(userId, id);
            if (data is null)
			{
                return Result.Warn(1, ErrorCode.NotFound);
            }
            if (data.UserId != userId)
			{
				return Result.Error(2, ErrorCode.NotAuthorized,AuthType.User.ToString());
            }
            if (data.DeleteDate.HasValue)
			{
                return Result.Warn(3, ErrorCode.AlreadyDeleted);
            }
			data.DeleteDate = DateTime.Now;
			var res = _addressRepo.Update(data);	
			if(!res)
			{
                return Result.DbInternal(4);
            }
			return Result.Success();
		}

		public List<Address> GetUserAddresses(int userId)
		{
			return _addressRepo.GetList(x => x.UserId == userId && !x.DeleteDate.HasValue);
		}

		public Result UpdateAddress(int userId,Address data)
		{
			var address = GetAddress(userId, data.Id);
			if(address is null) 
			{
                return Result.Warn(1, ErrorCode.NotFound);
            }
			if (address.UserId != userId)
			{
                return Result.Error(2, ErrorCode.NotAuthorized, AuthType.User.ToString());
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

        public Address? GetAddress(int addressId)
        {
			return _addressRepo.GetFirstOrDefault(x => x.Id == addressId && !x.DeleteDate.HasValue);
        }

        public Address? GetAddress(int userId, int addressId)
        {
            return _addressRepo.GetFirstOrDefault(x => x.Id == addressId && x.UserId == userId && !x.DeleteDate.HasValue);
        }
    }


}
