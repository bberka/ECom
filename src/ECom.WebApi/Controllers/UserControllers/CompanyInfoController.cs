using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class CompanyInfoController : BaseUserController
    {
        private readonly ICompanyInformationService _companyInformationService;

        public CompanyInfoController(ICompanyInformationService companyInformationService)
        {
            this._companyInformationService = companyInformationService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _companyInformationService.GetFromCache();
			return Ok(res);
        }


	}
}
