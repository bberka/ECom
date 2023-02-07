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
        public ActionResult RefreshCache()
        {
             _optionService.RefreshCache();
             return Ok();
        }
        [HttpGet]
		public ActionResult<Option> GetCurrentOption()
		{
			return _optionService.GetOption();
		}
		
		[HttpGet]
		public ActionResult<List<CargoOption>> ListCargoOptions()
		{
			return _optionService.GetCargoOptions();
		}
		[HttpGet]
		public ActionResult<List<PaymentOption>> ListPaymentOptions()
		{
			return _optionService.GetPaymentOptions();
		}
		[HttpGet]
		public ActionResult<List<SmtpOption>> ListSmtpOptions()
		{
			return _optionService.GetSmtpOptions();
		}
		[HttpPost]
		public ActionResult<Result> Update([FromBody] Option option)
		{
			var res = _optionService.UpdateOption(option);
			logger.Info($"Option({option.ToJsonString()})");
			return res;
		}

		
		[HttpPost]
		public ActionResult<Result> UpdateCargoOption([FromBody] CargoOption option)
		{
			var res = _optionService.UpdateCargoOption(option);
			logger.Info($"Option({option.ToJsonString()})");
			return res;
		}
		[HttpPost]
		public ActionResult<Result> UpdatePaymentOption([FromBody] PaymentOption option)
		{
			var res = _optionService.UpdatePaymentOption(option);
			logger.Info($"Option({option.ToJsonString()})");
			return res;
		}

		[HttpPost]
		public ActionResult<Result> UpdateSmtpOption([FromBody] SmtpOption option)
		{
			var res = _optionService.UpdateSmtpOption(option);
			logger.Info($"Option({option.ToJsonString()})");
			return res;
		}
	}
}
