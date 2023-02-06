using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class LanguageController : BaseUserController
	{
		private readonly ILanguageService _languageService;
		public LanguageController(ILanguageService languageService)
		{
			_languageService = languageService;
		}
		[HttpGet]
		[ResponseCache(Duration = 60)]
		public ActionResult<List<Language>> List()
		{
			return _languageService.GetLanguages();
		}

	}
}
