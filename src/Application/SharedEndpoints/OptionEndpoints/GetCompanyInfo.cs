using ECom.Domain.Entities;

namespace ECom.Application.SharedEndpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetCompanyInfo))]
public class GetCompanyInfo : EndpointBaseSync.WithoutRequest.WithResult<CompanyInformation>
{
  private readonly ICompanyInformationService _companyInformationService;

  public GetCompanyInfo(ICompanyInformationService companyInformationService) {
    _companyInformationService = companyInformationService;
  }

  [HttpGet]
  [ResponseCache(Duration = 60)]
  [EndpointSwaggerOperation(typeof(GetCompanyInfo), "Packs company information")]
  public override CompanyInformation Handle() {
    return _companyInformationService.GetCompanyInformation();
  }
}