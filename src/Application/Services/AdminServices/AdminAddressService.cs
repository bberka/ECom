using ECom.Application.Services.BaseServices;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminAddressService : AddressService,IAdminAddressService
{
  public AdminAddressService(IUnitOfWork unitOfWork) : base(unitOfWork) {
  }

  public CustomResult<Address> GetAddress(Guid addressId) {
    var address = UnitOfWork.AddressRepository.Find(addressId);
    if (address is null) return DomainResult.NotFound(nameof(Address));
    if (address.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Address));
    return address;
  }
}