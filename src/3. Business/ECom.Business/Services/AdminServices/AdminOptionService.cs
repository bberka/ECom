namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminOptionService : IAdminOptionService
{
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminOptionService(IOptionService optionService, IUnitOfWork unitOfWork) {
    _optionService = optionService;
    _unitOfWork = unitOfWork;
  }


  public Result UpdateOption(Option option) {
    option.Key = true;
    var dbData = _unitOfWork.Options;
    _unitOfWork.Options.RemoveRange(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateOption));
    option.UpdateDate = DateTime.Now;
    _unitOfWork.Options.Add(option);
    var res2 = _unitOfWork.Save();
    if (!res2) return DefResult.DbInternalError(nameof(UpdateOption));
    _optionService.SetCacheValue(option);
    return DefResult.OkUpdated(nameof(Option));
  }
}