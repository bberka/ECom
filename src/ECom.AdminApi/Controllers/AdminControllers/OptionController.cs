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
  [RequirePermission(AdminOperationType.OptionGet)]
  public ActionResult<Option> GetCurrentOption() {
    return _optionService.GetOption();
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.CargoOptionGet)]
  public ActionResult<List<CargoOption>> ListCargoOptions() {
    return _optionService.ListCargoOptions();
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.PaymentOptionGet)]
  public ActionResult<List<PaymentOption>> ListPaymentOptions() {
    return _optionService.ListPaymentOptions();
  }

  [HttpGet]
  [RequirePermission(AdminOperationType.SmtpOptionGet)]
  public ActionResult<List<SmtpOption>> ListSmtpOptions() {
    return _optionService.ListSmtpOptions();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.OptionUpdate)]
  public ActionResult<CustomResult> Update([FromBody] Option option) {
    var res = _optionService.UpdateOption(option);
    return res.ToActionResult();
  }


  [HttpPost]
  [RequirePermission(AdminOperationType.CargoOptionUpdate)]
  public ActionResult<CustomResult> UpdateCargoOption([FromBody] CargoOption option) {
    var res = _optionService.UpdateCargoOption(option);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.PaymentOptionUpdate)]
  public ActionResult<CustomResult> UpdatePaymentOption([FromBody] PaymentOption option) {
    var res = _optionService.UpdatePaymentOption(option);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.SmtpOptionUpdate)]
  public ActionResult<CustomResult> UpdateSmtpOption([FromBody] SmtpOption option) {
    var res = _optionService.UpdateSmtpOption(option);
    return res.ToActionResult();
  }
}