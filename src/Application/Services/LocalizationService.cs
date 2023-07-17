namespace ECom.Application.Services;

public class LocalizationService : ILocalizationService
{
  private readonly IUnitOfWork _unitOfWork;

  public LocalizationService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }
  public string GetLocalization(LanguageType languageType, string key) {
    if (string.IsNullOrEmpty(key)) return key;
    var localizationString = _unitOfWork.LocalizationStringRepository.GetFirstOrDefault(x => x.Language == languageType && x.Key == key);
    return localizationString?.Key ?? key;
  }

  public string GetLocalization(LanguageType languageType, string key, Dictionary<string, object> parameters) {
    var value = GetLocalization(languageType, key);
    var formatter = new StringFormatter(value);
    foreach (var parameter in parameters) {
      formatter.Add(parameter.Key, parameter.Value.ToString());
    }
    return formatter.ToString();
  }

  public CustomResult AddOrUpdateLocalization(LocalizationString localizationString) {
    var loc = _unitOfWork.LocalizationStringRepository.GetFirstOrDefault(x => x.Language == localizationString.Language && x.Key == localizationString.Key);
    if (loc == null) {
      _unitOfWork.LocalizationStringRepository.Insert(localizationString);
    }
    else {
      loc.Value = localizationString.Value;
      _unitOfWork.LocalizationStringRepository.Update(loc);
    }
    var res =_unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddOrUpdateLocalization));
    return DomainResult.OkUpdated(nameof(LocalizationString));
  }
  public CustomResult DeleteLocalization(LanguageType languageType, string key) {
    var loc = _unitOfWork.LocalizationStringRepository.GetFirstOrDefault(x => x.Language == languageType && x.Key == key);
    if (loc == null) return DomainResult.NotFound(nameof(LocalizationString));
    _unitOfWork.LocalizationStringRepository.Delete(loc);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteLocalization));
    return DomainResult.OkDeleted(nameof(LocalizationString));
  }
}