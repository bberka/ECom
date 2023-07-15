namespace ECom.WebApi.Endpoints.Option;

[AllowAnonymous]
[EndpointRoute(typeof(GetCompanyInformationEndpoint))]
public class GetCompanyInformationEndpoint : EndpointBaseSync.WithoutRequest.WithResult<CompanyInformation>
{
  private readonly ICompanyInformationService _companyInformationService;

  public GetCompanyInformationEndpoint(ICompanyInformationService companyInformationService) {
    _companyInformationService = companyInformationService;
  }
  [HttpGet]
  [ResponseCache(Duration = 60)]
  [EndpointSwaggerOperation(typeof(GetCompanyInformationEndpoint), "Get company information")]
  public override CompanyInformation Handle() {
    return _companyInformationService.GetFromCache() ?? throw new ArgumentNullException(nameof(CompanyInformation));
    
  }
}