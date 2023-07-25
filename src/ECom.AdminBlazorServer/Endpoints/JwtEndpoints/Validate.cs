using Ardalis.ApiEndpoints;
using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services.Admin;
using ECom.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.AdminBlazorServer.Endpoints.JwtEndpoints;

[EndpointRoute(typeof(Validate))]
public class Validate : EndpointBaseSync.WithRequest<ValidateTokenRequest>.WithResult<bool>
{
  private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;

  public Validate(IAdminJwtAuthenticator adminJwtAuthenticator) {
    _adminJwtAuthenticator = adminJwtAuthenticator;
  }

  [HttpPost]
  [AllowAnonymous]
  [EndpointSwaggerOperation(typeof(Validate), "Validates JWT token")]
  public override bool Handle(ValidateTokenRequest request) {
    return _adminJwtAuthenticator.Validate(request);
  }
}