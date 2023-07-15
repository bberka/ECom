using ECom.Domain.Lib;

namespace ECom.WebApi.Endpoints.Option;

[AllowAnonymous]
[EndpointRoute(typeof(GetLanguagesEndpoint))]
public class GetLanguagesEndpoint : EndpointBaseSync.WithoutRequest.WithResult<string[]>
{
    [HttpGet]
    [EndpointSwaggerOperation(typeof(GetLanguagesEndpoint), "List all supported languages")]
    public override string[] Handle()
    {
        return CommonLib.GetCultureNames();
    }
}