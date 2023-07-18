﻿using ECom.Domain.Entities;

namespace ECom.AdminApi.Endpoints.OptionEndpoints;

[EndpointRoute(typeof(UpdateOption))]
public class UpdateOption : EndpointBaseSync.WithRequest<Option>.WithResult<CustomResult>
{
  private readonly IOptionService _optionService;

  public UpdateOption(IOptionService optionService) {
    _optionService = optionService;
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.OptionUpdate)]
  [EndpointSwaggerOperation(typeof(UpdateOption), "Updates base option")]
  public override CustomResult Handle(Option request) {
    var res = _optionService.UpdateOption(request);
    return res;
  }
}