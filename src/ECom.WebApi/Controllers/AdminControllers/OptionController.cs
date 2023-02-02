using ECom.Infrastructure;
using ECom.Infrastructure.DependencyResolvers.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ECom.WebApi.Controllers.AdminControllers
{
	public class OptionController : BaseAdminController
	{
		private readonly IOptionService _optionService;
		public OptionController(IOptionService optionService)
		{
			_optionService= optionService;
		}
		[HttpGet]
		public IActionResult Get()
		{
			var option = _optionService.GetSingle();
			return Ok(option);
		}
		[HttpPost]
		public IActionResult Update([FromBody] Option option)
		{
			var res = _optionService.UpdateOption(option);
			if (!res.IsSuccess)
			{
				logger.Warn($"Option({option.ToJsonString()}) Result({res.ToJsonString()})");
				return BadRequest(res);
			}
			logger.Info($"Option({option.ToJsonString()})");
			return Ok(res);
		}

	}
}
