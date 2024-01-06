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
    if (!isValidModel) return DomResults.x_is_invalid("company_information");
    info.Key = CompanyInformation.SINGLE_KEY;
    var dbData = _unitOfWork.CompanyInformation;
    _unitOfWork.CompanyInformation.RemoveRange(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateCompanyInformation));
    _unitOfWork.CompanyInformation.Add(info);
    var res2 = _unitOfWork.Save();
    if (!res2) return DomResults.db_internal_error(nameof(UpdateCompanyInformation));
    _companyInformationService.SetCacheValue(info);
    return DomResults.x_is_updated_successfully("company_information");
  }
}