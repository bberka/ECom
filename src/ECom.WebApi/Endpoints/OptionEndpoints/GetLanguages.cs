using ECom.Application.Attributes;
using ECom.Domain.Lib;

namespace ECom.WebApi.Endpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetLanguages))]
public class GetLanguages : EndpointBaseSync.WithoutRequest.WithResult<string[]>
{
    [HttpGet]
    [EndpointSwaggerOperation(typeof(GetLanguages), "Gets all supported languages")]
    public override string[] Handle()
    {
        return CommonLib.GetCultureNames();
    }
}