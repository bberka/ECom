using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    public class CompanyInfoController : BaseAdminController
    {
        private readonly ICompanyInformationService _companyInformationService;
        private readonly ILogService _logService;

        public CompanyInfoController(
            ICompanyInformationService companyInformationService,
            ILogService logService)
        {
            this._companyInformationService = companyInformationService;
            _logService = logService;
        }
        [HttpPost]
        [HasPermission(AdminOperationType.CompanyInfo_AddOrUpdate)]
        public ActionResult<Result> AddOrUpdate(CompanyInformation companyInformation)
        {
            var adminId = HttpContext.GetAdminId();
            var res = _companyInformationService.UpdateOrAddCompanyInformation(companyInformation);
			_logService.AdminLog(res,adminId,"CompanyInformation.UpdateOrAdd",companyInformation.ToJsonString());
            return res.WithoutRv();
        }

	}
}
