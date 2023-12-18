namespace ECom.Service.Public;

public class GetLanguageTypes : EndpointBaseSync.WithoutRequest.WithResult<JsonResult>
{
  [AllowAnonymous]
  [Endpoint("/languages", HttpMethodType.GET)]
  [EndpointSwaggerOperation("Endpoints")]
  public override JsonResult Handle() {
    var enumValues = Enum.GetValues(typeof(LanguageType)).Cast<LanguageType>().ToDictionary(x => (int)x, x => x.ToString());
    return new JsonResult(enumValues);
  }
}