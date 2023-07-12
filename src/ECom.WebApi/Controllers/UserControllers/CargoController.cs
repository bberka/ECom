using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.UserControllers;

[AllowAnonymous]
public class CargoController : BaseUserController
{
  private readonly IOptionService _optionService;

  public CargoController(IOptionService optionService) {
    _optionService = optionService;
  }

  [HttpGet]
  public ActionResult<List<CargoOption>> Get() {
    return _optionService.ListCargoOptions();
  }
}