using ECom.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ECom.WebApi.Controllers.AdminControllers
{
	public class JwtOptionController : BaseAdminController
	{
		private readonly IJwtOptionService _jwtOptionService;
		public JwtOptionController(IJwtOptionService jwtOptionService)
		{
			_jwtOptionService = jwtOptionService;
		}
		[HttpGet]
		public IActionResult GetList()
		{
			var options = _jwtOptionService.GetList();
			return Ok(options);
		}
		[HttpGet]
		public IActionResult GetCurrent()
		{
			var option = _jwtOptionService.GetSingle();
			return Ok(option);
		}
		[HttpPost]
		public IActionResult Update([FromBody] JwtOption option)
		{
			var res = _jwtOptionService.UpdateJwtOption(option);
			if (!res.IsSuccess)
			{
				logger.Warn($"JwtOption({option.ToJsonString()}) Result({res.ToJsonString()})");
				return BadRequest(res);
			}
			logger.Info($"JwtOption({option.ToJsonString()})");
			return Ok(res);
		}


	}
}
