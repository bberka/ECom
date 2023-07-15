using AspNetCore.Authorization.Extender;
using ECom.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers;

public class OptionController : BaseAdminController
{
  private readonly ILogService _logService;
  private readonly IOptionService _optionService;

  public OptionController(
    IOptionService optionService,
    ILogService logService) {
    _optionService = optionService;
    _logService = logService;
  }


  [HttpGet]
  [RequirePermission(AdminOperationType.Option_Get)]
  public ActionResult<Option> GetCurrentOption() {
    return _optionService.GetOption();
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.CargoOption_Get)]
  public ActionResult<List<CargoOption>> ListCargoOptions() {
    return _optionService.ListCargoOptions();
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.PaymentOption_Get)]
  public ActionResult<List<PaymentOption>> ListPaymentOptions() {
    return _optionService.ListPaymentOptions();
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.SmtpOption_Get)]
  public ActionResult<List<SmtpOption>> ListSmtpOptions() {
    return _optionService.ListSmtpOptions();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Option_Update)]
  public ActionResult<Result> Update([FromBody] Option option) {
    var res = _optionService.UpdateOption(option);
    return res.ToActionResult();
  }


  [HttpPost]
  [RequirePermission(AdminOperationType.CargoOption_Update)]
  public ActionResult<Result> UpdateCargoOption([FromBody] CargoOption option) {
    var res = _optionService.UpdateCargoOption(option);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.PaymentOption_Update)]
  public ActionResult<Result> UpdatePaymentOption([FromBody] PaymentOption option) {
    var res = _optionService.UpdatePaymentOption(option);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.SmtpOption_Update)]
  public ActionResult<Result> UpdateSmtpOption([FromBody] SmtpOption option) {
    var res = _optionService.UpdateSmtpOption(option);
    return res.ToActionResult();
  }
}