using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
	public class LanguageController : BaseUserController
	{
		private readonly ILanguageService _languageService;
		public LanguageController(ILanguageService languageService)
		{
			_languageService = languageService;
		}
		[HttpGet]
		public IActionResult List()
		{
			var res = _languageService.GetLanguages();
			return Ok(res);
		}
		
	}
}
