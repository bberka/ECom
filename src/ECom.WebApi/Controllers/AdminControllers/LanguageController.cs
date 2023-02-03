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
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters);
				return BadRequest(res);
			}
			logger.Info("Language EnabledOrDisabled: " + id);
			return Ok(res);
		}

		[HttpPost]
		public IActionResult Get([FromBody] int id)
		{
			var res = _languageService.GetLanguageById(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters);
				return BadRequest(res);
			}
			logger.Info(res.Data.ToJsonString());
			return Ok(res);
		}
	}
}
