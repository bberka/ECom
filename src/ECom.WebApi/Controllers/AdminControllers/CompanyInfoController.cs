using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    public class CompanyInfoController : BaseAdminController
    {
        private readonly ICompanyInformationService _companyInformationService;

        public CompanyInfoController(ICompanyInformationService companyInformationService)
        {
            this._companyInformationService = companyInformationService;
        }
        [HttpPost]
        public ActionResult<Result> Update(CompanyInformation companyInformation)
        {
            var res = _companyInformationService.UpdateCompanyInformation(companyInformation);
			return res;
        }

	}
}
