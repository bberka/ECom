using ECom.Domain.Constants;
using ECom.Domain.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class LanguageController : BaseUserController
	{
		
		[HttpGet]
		public ActionResult<string[]> List()
        {
            return CommonLib.GetCultureNames();
		}

        
    }
}
