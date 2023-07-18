using Ardalis.ApiEndpoints;
using ECom.Application.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Application.SharedEndpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetPaymentInfo))]
public class GetPaymentInfo : EndpointBaseSync.WithoutRequest.WithResult<List<PaymentOption>>
{
    private readonly IOptionService _optionService;

    public GetPaymentInfo(IOptionService optionService)
    {
        _optionService = optionService;
    }
    [HttpGet]
    [EndpointSwaggerOperation(typeof(GetPaymentInfo), "Gets payment information")]
    public override List<PaymentOption> Handle()
    {
        return _optionService.ListPaymentOptions();

    }
}