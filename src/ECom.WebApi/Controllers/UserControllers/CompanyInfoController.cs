using ECom.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class CompanyInfoController : BaseUserController
    {
        private readonly ICompanyInformationService _companyInformationService;

        public CompanyInfoController(ICompanyInformationService companyInformationService)
        {
            this._companyInformationService = companyInformationService;
        }
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public ActionResult<CompanyInformation?> Get()
        {
            return _companyInformationService.GetFromCache();
        }


	}
}
