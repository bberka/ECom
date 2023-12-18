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
    var data = _unitOfWork.CargoOptions.Find(id);
    if (data is null) return DefResult.NotFound(CargoOption.LocKey);
    data.DeleteDate = DateTime.Now;
    _unitOfWork.CargoOptions.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteCargoOption));
    _cargoOptionService.ClearCache();
    return DefResult.OkDeleted(CargoOption.LocKey);
  }

  public Result UpdateCargoOption(CargoOption option) {
    _unitOfWork.CargoOptions.Update(option);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateCargoOption));
    _cargoOptionService.ClearCache();
    return DefResult.OkUpdated(nameof(UpdateCargoOption));
  }

  public Result AddCargoOption(CargoOption model) {
    throw new NotImplementedException();
  }
}