using ECom.Domain.Results;

namespace ECom.Application.Services
{

	public class AddressService : IAddressService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

		public AddressService(
			IUnitOfWork unitOfWork,
			IUserService userService)
        {
            _unitOfWork = unitOfWork;
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
			_unitOfWork.AddressRepository.Update(address);
            var res = _unitOfWork.Save();
			if(!res)
            {
                return DomainResult.DbInternalErrorResult(4);
            }
            return DomainResult.Address.DeleteSuccessResult();
		}

		public List<Address> GetUserAddresses(int userId)
		{
			return _unitOfWork.AddressRepository.GetList(x => x.UserId == userId && !x.DeleteDate.HasValue);
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
            _unitOfWork.AddressRepository.Update(data);
            if (!_unitOfWork.Save())
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.Address.UpdateSuccessResult();
		}

		public Result AddAddress(int userId,Address address)
		{
			_unitOfWork.AddressRepository.Add(address);
			if (!_unitOfWork.Save())
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Address.AddSuccessResult();
		}

        public ResultData<Address> GetAddress(int addressId)
        {
			var address = _unitOfWork.AddressRepository.Find(addressId);
            if (address is null) return DomainResult.Address.NotFoundResult(1);
            if(address.DeleteDate.HasValue) return DomainResult.Address.DeletedResult(2);
            return address;
        }

        public ResultData<Address> GetAddress(int userId, int addressId)
        {
            var addressResult = GetAddress(addressId);
            if (addressResult.IsFailure)
            {
                return addressResult.ToResult(100);
            }
            var isAuthorized = addressResult.Data?.UserId == userId;
            if (isAuthorized == false)
            {
                return DomainResult.User.NotAuthorizedResult(2);
            }
            return addressResult.Data;

        }
    }


}
