using ECom.Database;
using ECom.Foundation.Static;

namespace ECom.Service.PublicApi.Controllers;

public class InformationController : PublicControllerBase
{
  [Endpoint("/health", HttpMethodType.GET)]
  [ResponseCache(Duration = 3, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Health() {
    return Ok("200!");
  }

  [Endpoint("/db-health", HttpMethodType.GET)]
  [ResponseCache(Duration = 10, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult DatabaseHealth([FromServices] EComDbContext dbContext) {
    var isDbConnected = dbContext.Database.CanConnect();
    return isDbConnected
             ? Ok("200!")
             : StatusCode(500);
  }

  [Endpoint("/get-languages", HttpMethodType.GET)]
  [ResponseCache(Duration = 60, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult GetLanguages() {
    var dictionary = StaticValues.LANGUAGES.ToDictionary(x => (int)x, x => x.ToString());
    return Ok(dictionary);
  }

  [Endpoint("/get-static", HttpMethodType.GET)]
  [ResponseCache(Duration = 60, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult GetStatic() {
    return Ok(StaticValues.GetAllForJson());
  }
}