using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Abstract.Services.User;
using ECom.Domain.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class AddressService : IAddressService
{
  protected readonly IUnitOfWork UnitOfWork;

  protected AddressService(
    IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }
  public List<Address> GetUserAddresses(Guid userId) {
    return UnitOfWork.AddressRepository.Get(x => x.UserId == userId && !x.DeleteDate.HasValue).ToList();
  }


}