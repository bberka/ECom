using Ardalis.ApiEndpoints;
using ECom.WebApi.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Endpoints;

[AllowAnonymous]
[EndpointRoute(typeof(Status))]
public class Status : EndpointBaseSync.WithoutRequest.WithResult<JsonResult>
{
  [HttpGet]
  [EndpointSwaggerOperation(typeof(Status), "Gets server status")]
  public override JsonResult Handle() {
    return new JsonResult("200!");
  }
}