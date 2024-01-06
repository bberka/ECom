using ECom.Database;
using ECom.Foundation.Static;

namespace ECom.Service.PublicApi.Controllers;

public class InformationController : PublicControllerBase
{
  [Endpoint("/health", HttpMethodType.GET)]
  public IActionResult Health() {
    return Ok("200!");
  }

  [Endpoint("/db-health", HttpMethodType.GET)]
  public IActionResult DatabaseHealth([FromServices] EComDbContext dbContext) {
    var isDbConnected = dbContext.Database.CanConnect();
    return isDbConnected
             ? Ok("200!")
             : StatusCode(500);
  }

  [Endpoint("/get-languages", HttpMethodType.GET)]
  public IActionResult GetLanguages() {
    var dictionary = StaticValues.LANGUAGES.ToDictionary(x => (int)x, x => x.ToString());
    return Ok(dictionary);
  }
}