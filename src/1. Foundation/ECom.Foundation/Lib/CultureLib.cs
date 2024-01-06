using System.Globalization;
using System.Text.RegularExpressions;
using ECom.Foundation.Static;

namespace ECom.Foundation.Lib;

public class CultureLib : SingletonBase<CultureLib>
{
  private readonly Dictionary<string, Dictionary<string, string>> _cultureDict = new();

  private CultureLib() {
    const string folderName = "LanguagePacks";
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
    var files = Directory.GetFiles(path, "*.json");
    if (files.Length == 0) {
      throw new Exception($"No cultureType pack found in {path}");
    }

    foreach (var file in files) {
      var fileName = Path.GetFileNameWithoutExtension(file);
      if (fileName.IsNullOrEmpty()) continue;
      var culture = fileName.ToLower();
      var text = File.ReadAllText(file);
      var dict = ProcessLanguageData(text);
      _cultureDict.Add(culture, dict);
    }

    var defaultCultureExists = _cultureDict.ContainsKey(StaticValues.DEFAULT_CULTURE_NAME);
    if (!defaultCultureExists) {
      throw new Exception($"Default culture {StaticValues.DEFAULT_CULTURE_NAME} not found in {path}");
    }
  }

  private Dictionary<string, string> ProcessLanguageData(string text) {
    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
    var processedDict = new Dictionary<string, string>();
    foreach (var entry in dict) {
      processedDict[entry.Key] = GetProcessedTranslationText(entry.Value);
    }

    return processedDict;
  }

  private string GetProcessedTranslationText(string input) {
    //Converts {Name} or any {any value} to {0} => index to be used in string.Format
    var regex = new Regex(@"\{.*?\}");
    var index = 0;
    return regex.Replace(input, match => $"{{{index++}}}");
  }

  public string Get(string key) {
    var dict = GetCulture(GetCultureNameKey());
    if (dict.TryGetValue(key, out var value)) return value;
    return key;
  }

  public string GetWithParams(string key,
                              object[] pList) {
    var translated = Get(key);
    if (translated == key) return translated; // no translation found
    var formatted = string.Format(translated, pList);
    return translated;
  }

  private IReadOnlyDictionary<string, string> GetCulture(string culture) {
    if (_cultureDict.TryGetValue(culture, out var dict)) return dict;
    return _cultureDict[StaticValues.DEFAULT_CULTURE_NAME];
  }

  private string GetCultureNameKey() {
    var culture = CultureInfo.CurrentCulture
                  ?? CultureInfo.CurrentUICulture
                  ?? StaticValues.DEFAULT_CULTURE;
    var name = culture.Name.ToLower(StaticValues.DEFAULT_CULTURE);
    return name;
  }
}