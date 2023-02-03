using ECom.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ECom.WebApi.Controllers.AdminControllers
{
	public class OptionController : BaseAdminController
	{
		private readonly IOptionService _optionService;
		public OptionController(IOptionService optionService)
		{
			_optionService = optionService;
		}
		
		[HttpGet]
		public IActionResult GetCurrentOption()
		{
			var option = _optionService.GetOption();
			return Ok(option);
		}
		[HttpGet]
		public IActionResult GetCurrentJwtOption()
		{
			var option = _optionService.GetJwtOption();
			return Ok(option);
		}
		[HttpGet]
		public IActionResult ListCargoOptions()
		{
			var option = _optionService.GetCargoOptions();
			return Ok(option);
		}
		[HttpGet]
		public IActionResult ListPaymentOptions()
		{
			var option = _optionService.GetPaymentOptions();
			return Ok(option);
		}
		[HttpGet]
		public IActionResult ListSmtpOptions()
		{
			var option = _optionService.GetSmtpOptions();
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

		[HttpPost]
		public IActionResult UpdateJwtOption([FromBody] JwtOption option)
		{
			var res = _optionService.UpdateJwtOption(option);
			if (!res.IsSuccess)
			{
				logger.Warn($"Option({option.ToJsonString()}) Result({res.ToJsonString()})");
				return BadRequest(res);
			}
			logger.Info($"Option({option.ToJsonString()})");
			return Ok(res);
		}
		[HttpPost]
		public IActionResult UpdateCargoOption([FromBody] CargoOption option)
		{
			var res = _optionService.UpdateCargoOption(option);
			if (!res.IsSuccess)
			{
				logger.Warn($"Option({option.ToJsonString()}) Result({res.ToJsonString()})");
				return BadRequest(res);
			}
			logger.Info($"Option({option.ToJsonString()})");
			return Ok(res);
		}
		[HttpPost]
		public IActionResult UpdatePaymentOption([FromBody] PaymentOption option)
		{
			var res = _optionService.UpdatePaymentOption(option);
			if (!res.IsSuccess)
			{
				logger.Warn($"Option({option.ToJsonString()}) Result({res.ToJsonString()})");
				return BadRequest(res);
			}
			logger.Info($"Option({option.ToJsonString()})");
			return Ok(res);
		}

		[HttpPost]
		public IActionResult UpdateSmtpOption([FromBody] SmtpOption option)
		{
			var res = _optionService.UpdateSmtpOption(option);
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
