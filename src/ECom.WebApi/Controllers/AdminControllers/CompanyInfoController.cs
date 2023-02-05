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
        public IActionResult Update(CompanyInformation companyInformation)
        {
            var res = _companyInformationService.UpdateCompanyInformation(companyInformation);
			return Ok(res);
        }

	}
}
