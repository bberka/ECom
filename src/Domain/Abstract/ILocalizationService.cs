namespace ECom.Domain.Abstract;

public interface ILocalizationService
{
  public string GetLocalization(LanguageType languageType,string key);
  public string GetLocalization(LanguageType languageType, string key, Dictionary<string, object> parameters);
  public CustomResult AddOrUpdateLocalization(LocalizationString localizationString);
  //public CustomResult Update(LocalizationString localizationString);
  public CustomResult DeleteLocalization(LanguageType languageType,string key);
}