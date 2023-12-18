namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminCompanyInformationService : IAdminCompanyInformationService
{
  private readonly ICompanyInformationService _companyInformationService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminCompanyInformationService(
    IUnitOfWork unitOfWork,
    ICompanyInformationService companyInformationService) {
    _unitOfWork = unitOfWork;
    _companyInformationService = companyInformationService;
  }

  public Result UpdateCompanyInformation(CompanyInformation info) {
    var isValidModel = info.IsValidModel();
    if (!isValidModel) return DefResult.InvalidState(CompanyInformation.LocKey);
    info.Key = CompanyInformation.SingleKey;
    var dbData = _unitOfWork.CompanyInformation;
    _unitOfWork.CompanyInformation.RemoveRange(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateCompanyInformation));
    _unitOfWork.CompanyInformation.Add(info);
    var res2 = _unitOfWork.Save();
    if (!res2) return DefResult.DbInternalError(nameof(UpdateCompanyInformation));
    _companyInformationService.SetCacheValue(info);
    return DefResult.OkUpdated(CompanyInformation.LocKey);
  }
}