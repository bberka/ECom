﻿using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
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
        [HasPermission(AdminOperationType.Option_RefreshCache)]
        public ActionResult RefreshCache()
        {
             _optionService.RefreshCache();
             return Ok();
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
			return _optionService.GetCargoOptions();
		}
		[HttpGet]
        [HasPermission(AdminOperationType.PaymentOption_Get)]
        public ActionResult<List<PaymentOption>> ListPaymentOptions()
		{
			return _optionService.GetPaymentOptions();
		}
		[HttpGet]
        [HasPermission(AdminOperationType.SmtpOption_Get)]
        public ActionResult<List<SmtpOption>> ListSmtpOptions()
		{
			return _optionService.GetSmtpOptions();
		}
		[HttpPost]
        [HasPermission(AdminOperationType.Option_Update)]
        public ActionResult<Result> Update([FromBody] Option option)
		{
			var res = _optionService.UpdateOption(option);
			logger.Info($"Option({option.ToJsonString()})");
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
