using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using ECom.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ECom.WebApi.Controllers.AdminControllers
{
	public class OptionController : BaseAdminController
	{
		private readonly IOptionService _optionService;
        private readonly ILogService _logService;

        public OptionController(
            IOptionService optionService,
            ILogService logService)
        {
            _optionService = optionService;
            _logService = logService;
        }

        
        [HttpGet]
        [HasPermission(AdminOperationType.Option_Get)]
        public ActionResult<Option> GetCurrentOption()
		{
			return _optionService.GetOption();
		}
		
		[HttpGet]
        [HasPermission(AdminOperationType.CargoOption_Get)]
        public ActionResult<List<CargoOption>> ListCargoOptions()
		{
			return _optionService.ListCargoOptions();
		}
		[HttpGet]
        [HasPermission(AdminOperationType.PaymentOption_Get)]
        public ActionResult<List<PaymentOption>> ListPaymentOptions()
		{
			return _optionService.ListPaymentOptions();
		}
		[HttpGet]
        [HasPermission(AdminOperationType.SmtpOption_Get)]
        public ActionResult<List<SmtpOption>> ListSmtpOptions()
		{
			return _optionService.ListSmtpOptions();
		}
		[HttpPost]
        [HasPermission(AdminOperationType.Option_Update)]
        public ActionResult<Result> Update([FromBody] Option option)
		{
			var res = _optionService.UpdateOption(option);
			return res.WithoutRv();
		}

		
		[HttpPost]
        [HasPermission(AdminOperationType.CargoOption_Update)]
        public ActionResult<Result> UpdateCargoOption([FromBody] CargoOption option)
		{
			var res = _optionService.UpdateCargoOption(option);
			return res.WithoutRv();
		}
		[HttpPost]
        [HasPermission(AdminOperationType.PaymentOption_Update)]
        public ActionResult<Result> UpdatePaymentOption([FromBody] PaymentOption option)
		{
			var res = _optionService.UpdatePaymentOption(option);
			return res.WithoutRv();
		}

		[HttpPost]
        [HasPermission(AdminOperationType.SmtpOption_Update)]
        public ActionResult<Result> UpdateSmtpOption([FromBody] SmtpOption option)
		{
			var res = _optionService.UpdateSmtpOption(option);
			return res.WithoutRv();
		}
	}
}
