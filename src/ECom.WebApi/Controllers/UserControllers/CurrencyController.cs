using ECom.Domain.Lib;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.UserControllers;

[AllowAnonymous]
public class CurrencyController : BaseUserController
{
  [HttpGet]
  public ActionResult<string[]> Get() {
    return CommonLib.GetCurrencyTypes();
  }
}