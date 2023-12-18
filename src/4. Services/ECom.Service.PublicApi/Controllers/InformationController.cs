using ECom.Database;

namespace ECom.Service.PublicApi.Controllers;

public class InformationController : PublicControllerBase
{
  [Endpoint("/health", HttpMethodType.GET)]
  public IActionResult Health() {
    return Ok();
  }

  [Endpoint("/db-health", HttpMethodType.GET)]
  public IActionResult DatabaseHealth([FromServices] EComDbContext dbContext) {
    var isDbConnected = dbContext.Database.CanConnect();
    return isDbConnected
             ? Ok()
             : StatusCode(500);
  }

  [Endpoint("/get-languages", HttpMethodType.GET)]
  public IActionResult GetLanguages() {
    var dictionary = ConstantContainer.Languages.ToDictionary(x => (int)x, x => x.ToString());
    return Ok(dictionary);
  }
}