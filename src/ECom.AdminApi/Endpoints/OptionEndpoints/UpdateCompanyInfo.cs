using ECom.Domain.Entities;

namespace ECom.AdminApi.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(UpdateCompanyInfo))]
public class UpdateCompanyInfo : EndpointBaseSync.WithRequest<CompanyInformation>.WithResult<CustomResult>
{
  private readonly ICompanyInformationService _companyInformationService;
  private readonly ILogService _logService;
  public UpdateCompanyInfo(
    ICompanyInformationService companyInformationService,
    ILogService logService) {
    _companyInformationService = companyInformationService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CompanyInfoAdd)]
  [EndpointSwaggerOperation(typeof(UpdateCompanyInfo),"Updates company information")]
  public override CustomResult Handle(CompanyInformation request)
  {
    var adminId = HttpContext.GetAdminId();
    var res = _companyInformationService.UpdateOrAddCompanyInformation(request);
    _logService.AdminLog(res, adminId, "CompanyInformation.Update", request.ToJsonString());
    return res;
  }
}