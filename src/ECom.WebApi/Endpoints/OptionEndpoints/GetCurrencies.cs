using ECom.Application.Attributes;
using ECom.Domain.Lib;

namespace ECom.WebApi.Endpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetCurrencies))]
public class GetCurrencies : EndpointBaseSync.WithoutRequest.WithResult<string[]>
{
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetCurrencies), "Get all currency types")]
  public override string[] Handle() {
    return CommonLib.GetCurrencyTypes();

  }
}