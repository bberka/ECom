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
            var addressResult = GetAddress(userId, id);
            if (addressResult.IsFailure)
            {
                return addressResult.ToResult(10);
            }
            var address = addressResult.Data;
            if (address is null)
            {
                return DomainResult.Address.NotFoundResult(1);
            }
            if (address.DeleteDate.HasValue)
            {
                return DomainResult.Address.AlreadyDeletedResult(3);
            }
			address.DeleteDate = DateTime.Now;
			var res = _addressRepo.Update(address);	
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
			var addressResult = GetAddress(userId, data.Id);
            if (addressResult.IsFailure)
            {
                return addressResult.ToResult(10);
            }
            var address = addressResult.Data;
            if (address.DeleteDate.HasValue)
            {
                return DomainResult.Address.DeletedResult(1);
            }
            var res = _addressRepo.Update(data);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
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

        public ResultData<Address> GetAddress(int addressId)
        {
			var address = _addressRepo.GetFirstOrDefault(x => x.Id == addressId && !x.DeleteDate.HasValue);
            if (address is null)
            {
                return DomainResult.Address.NotFoundResult(1);
            }
            return address;
        }

        public ResultData<Address> GetAddress(int userId, int addressId)
        {
            var address = _addressRepo.GetFirstOrDefault(x => x.Id == addressId && !x.DeleteDate.HasValue);
            if (address is null)
            {
                return DomainResult.Address.NotFoundResult(1);
            }

            var isAuthorized = address.UserId == userId;
            if (!isAuthorized)
            {
                return DomainResult.User.NotAuthorizedResult(2);
            }
            return address;

        }
    }


}
