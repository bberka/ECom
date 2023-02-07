using ECom.Domain.Results;

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
                return DomainResult.Address.NotFoundResult(1);
            }
            if (data.UserId != userId)
            {
                return DomainResult.User.NotAuthorizedResult(2);
            }
            if (data.DeleteDate.HasValue)
            {
                return DomainResult.Address.AlreadyDeletedResult(3);
            }
			data.DeleteDate = DateTime.Now;
			var res = _addressRepo.Update(data);	
			if(!res)
            {
                return DomainResult.DbInternalErrorResult(4);
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
                return DomainResult.Address.NotFoundResult(1);
            }
			if (address.UserId != userId)
            {
                return DomainResult.User.NotAuthorizedResult(2);
            }
            if (address.DeleteDate.HasValue)
            {
                return DomainResult.Address.DeletedResult(3);
            }
            var res = _addressRepo.Update(data);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(4);
            }

            return DomainResult.Address.UpdateSuccessResult();
		}

		public Result AddAddress(int userId,Address address)
		{
			var res = _addressRepo.Add(address);
			if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }

            return DomainResult.Address.AddSuccessResult();
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
