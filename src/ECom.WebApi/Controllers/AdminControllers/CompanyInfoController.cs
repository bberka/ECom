namespace ECom.WebApi.Controllers.AdminControllers;

public class CompanyInfoController : BaseAdminController
{
  private readonly ICompanyInformationService _companyInformationService;
  private readonly ILogService _logService;

  public CompanyInfoController(
    ICompanyInformationService companyInformationService,
    ILogService logService) {
    _companyInformationService = companyInformationService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CompanyInfo_AddOrUpdate)]
  public ActionResult<Result> AddOrUpdate(CompanyInformation companyInformation) {
    var adminId = HttpContext.GetAdminId();
    var res = _companyInformationService.UpdateOrAddCompanyInformation(companyInformation);
    _logService.AdminLog(res, adminId, "CompanyInformation.UpdateOrAdd", companyInformation.ToJsonString());
    return res.ToActionResult();
  }
}