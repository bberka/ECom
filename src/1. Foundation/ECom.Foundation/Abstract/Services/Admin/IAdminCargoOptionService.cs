using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminCargoOptionService
{
  Result UpdateCargoOption(CargoOption option);
  Result DeleteCargoOption(Guid id);
  Result AddCargoOption(CargoOption model);
}