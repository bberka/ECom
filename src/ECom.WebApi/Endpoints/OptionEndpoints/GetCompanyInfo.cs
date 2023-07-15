using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.OptionEndpoints;

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
  [EndpointSwaggerOperation(typeof(GetCompanyInfo), "Get company information")]
  public override CompanyInformation Handle() {
    return _companyInformationService.GetFromCache() ?? throw new ArgumentNullException(nameof(CompanyInformation));
    
  }
}