using ECom.Database;
using ECom.Database.Specifications;

namespace ECom.Business.Services.AdminServices;

public class AdminCargoOptionService : IAdminCargoOptionService
{
  private readonly ICargoOptionService _cargoOptionService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminCargoOptionService(IUnitOfWork unitOfWork, ICargoOptionService cargoOptionService) {
    _unitOfWork = unitOfWork;
    _cargoOptionService = cargoOptionService;
  }

  public Result DeleteCargoOption(Guid id) {
    var data = _unitOfWork.CargoOptions
                          .GetQuery(new GetCargoOptionByIdSpec(id))
                          .First();
    if (data is null)
      return DomResults.x_is_not_found("cargo_option");
    data.DeleteDate = DateTime.Now;
    _unitOfWork.CargoOptions.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(DeleteCargoOption));
    _cargoOptionService.ClearCache();
    return DomResults.x_is_deleted_successfully("cargo_option");
  }

  public Result UpdateCargoOption(CargoOption option) {
    _unitOfWork.CargoOptions.Update(option);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateCargoOption));
    _cargoOptionService.ClearCache();
    return DomResults.x_is_updated_successfully("cargo_option");
  }

  public Result AddCargoOption(CargoOption model) {
    throw new NotImplementedException();
  }
}