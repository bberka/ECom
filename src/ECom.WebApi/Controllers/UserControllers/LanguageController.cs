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


		[HttpPut]
		public IActionResult EnableOrDisable(int id)
		{
			var res = _languageService.EnableOrDisable(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters);
				return BadRequest(res);
			}
			logger.Info("Language EnabledOrDisabled: " + id);
			return Ok(res);
		}

		[HttpGet]
		public IActionResult Get(int id)
		{
			var res = _languageService.GetLanguageById(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters,);
				return BadRequest(res);
			}
			logger.Info(res.Data.ToJsonString());
			return Ok(res);
		}
	}
}
