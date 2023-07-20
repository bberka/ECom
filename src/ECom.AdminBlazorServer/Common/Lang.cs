using EasMe.Extensions;
using ECom.Shared;
using ECom.Shared.Constants;
using System.Collections.ObjectModel;
using System.Globalization;

namespace ECom.AdminBlazorServer.Common;

public static class Lang
{
  //private static readonly LanguagePackResultDTO LanguagePacks = 
  //  new LanguagePackResultDTO(new Dictionary<LanguageType, ReadOnlyCollection<LocalizationStringDTO>>() {
  //    {LanguageType.English,English.Pack},
  //    {LanguageType.Turkish,Turkish.Pack},
  //  }.AsReadOnly());

  public static ReadOnlyDictionary<LanguageType, ReadOnlyDictionary<string, string>> LanguagePacks {
    get {
      _languagePacks ??= ReadLanguageJson();
      return _languagePacks;

    }
  }

  private static ReadOnlyDictionary<LanguageType, ReadOnlyDictionary<string, string>>? _languagePacks;
  private static ReadOnlyDictionary<LanguageType, ReadOnlyDictionary<string, string>> ReadLanguageJson() {
    var languageJsonPathInWWWRoot = "language.json";
    var currentDirectory = Directory.GetCurrentDirectory();
    var languageJsonPath = Path.Combine(currentDirectory, "wwwroot", languageJsonPathInWWWRoot);
    var json = File.ReadAllText(languageJsonPath);
    var result = json.FromJsonString<Dictionary<LanguageType, Dictionary<string, string>>>();
    return result?.ToDictionary(x => x.Key, x => x.Value.AsReadOnly()).AsReadOnly() ?? throw new Exception("language.json not found");
  }
  private static ReadOnlyDictionary<string, string> GetLanguagePack(LanguageType type) {
    var value = LanguagePacks.GetValueOrDefault(type);
    if (value is null) {
      return new Dictionary<string, string>().AsReadOnly();
    }
    return value;
  }
  private static string GetCurrentCulture() {
    var culture = CultureInfo.CurrentCulture;
    return culture.Name;
  }

  public static string Get(string key, LanguageType langKey = LanguageType.English) {
    var langPack = GetLanguagePack(langKey);
    key = key.ToLower();
    var value = langPack.FirstOrDefault(x => x.Key == key,new KeyValuePair<string, string>(key,key));
    return value.Value;

  }
  public static string Get(object key, LanguageType langKey = LanguageType.English) {
    var langPack = GetLanguagePack(langKey);
    var keyStr = key.ToString()?.ToLower() ?? "";
    var value = langPack.FirstOrDefault(x => x.Key == keyStr, new KeyValuePair<string, string>(keyStr, keyStr));
    return value.Value;

  }
  public static string Get(params string[] keys) {
    var values = keys.Select(x => Get(x));
    return string.Join(" ", values);
  }


  public static string GetError(string errorCode, LanguageType langKey = LanguageType.English) {
    var splitKey = errorCode.Split('.');
    if (splitKey.Length != 2) {
      return errorCode;
    }
    var objName = splitKey[0];
    var error = splitKey[1];
    var message = Get(error, langKey);
    var formatter = new StringFormatter(message);
    formatter.AddArgument("name", objName);
    return formatter.ToString();
  }

  public static string Get(string key, params KeyValuePair<string,object>[] args) {
    var value = Get(key);
    var formatter = new StringFormatter(value);
    for (int i = 0; i < args.Length; i++) {
      var arg = args[i];
      formatter.AddArgument(i.ToString(), arg);
    }
    return formatter.ToString();
  }
  public static string Get(string key, params LocalizationParam[] args) {
    var value = Get(key);
    var formatter = new StringFormatter(value);
    foreach (var localizationParam in args) {
      localizationParam.TranslatedKey = Get(localizationParam.Value);
      formatter.AddArgument(localizationParam);
    }
    var result = formatter.ToString();
    return result;
  }

  //public static string GetMessage(CustomResult result) {
  //  var errorCode = result.ErrorCode;
  //  var langKey = LanguageType.English;
  //  var errorTranslated = GetError(errorCode, langKey);

  //}



}