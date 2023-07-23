using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Net.Http.Json;
using System.Security.Cryptography;
using ECom.AdminBlazor.Client.Common.Packs;
using ECom.Shared;
using ECom.Shared.Constants;
using ECom.Shared.DTOs.LocalizationStringDto;
using Newtonsoft.Json;

namespace ECom.AdminBlazor.Client.Common;

public static class Lang
{
  private static readonly LanguagePackResultDTO LanguagePacks = 
    new LanguagePackResultDTO(new Dictionary<LanguageType, ReadOnlyCollection<LocalizationStringDTO>>() {
      {LanguageType.English,English.Pack},
      {LanguageType.Turkish,Turkish.Pack},
    }.AsReadOnly());

  private static ReadOnlyCollection<LocalizationStringDTO> GetLanguagePack(LanguageType type) {
    var value = LanguagePacks.Packs.GetValueOrDefault(type);
    if (value is null) {
      return new List<LocalizationStringDTO>().AsReadOnly();
    }
    return value;
  }
  private static string GetCurrentCulture() {
    var culture = CultureInfo.CurrentCulture;
    return culture.Name;
  }

  public static string Get(string key, LanguageType langKey = LanguageType.English) {
    var langPack = GetLanguagePack(langKey);
    var value = langPack.FirstOrDefault(x => x.Key == key);
    return value?.Value ?? key;

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



}