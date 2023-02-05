using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
	public class LanguageController : BaseAdminController
	{
		private readonly ILanguageService _languageService;
		public LanguageController(ILanguageService languageService)
		{
			_languageService = languageService;
		}

		[HttpPut]
		public IActionResult EnableOrDisable([FromBody] int id)
		{
			var res = _languageService.EnableOrDisable(id);
			logger.Info("Language EnabledOrDisabled: " + id);
			return Ok(res);
		}

		[HttpPost]
		public IActionResult Get([FromBody] int id)
		{
			var res = _languageService.GetLanguage(id);
			return Ok(res);
		}
	}
}
