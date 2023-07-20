namespace ECom.Application.SharedEndpoints.LocalizationEndpoints;

[EndpointRoute(typeof(Packs))]
[AllowAnonymous]
public class Packs : EndpointBaseSync.WithoutRequest.WithResult<LanguagePackResultDTO>
{
  private readonly ILocalizationService _localizationService;

  public Packs(ILocalizationService localizationService) {
    _localizationService = localizationService;
  }

  [HttpGet]
  [EndpointSwaggerOperation(typeof(Packs), "Gets language packs")]
  [ResponseCache(Duration = 60 * 60)]
  public override LanguagePackResultDTO Handle() {
    return _localizationService.GetLanguagePacks();
  }
}