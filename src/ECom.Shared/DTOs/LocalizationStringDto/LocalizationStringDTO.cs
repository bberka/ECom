namespace ECom.Shared.DTOs.LocalizationStringDto;

public class LocalizationStringDTO
{

  public LocalizationStringDTO(string key, string value) {
    Key = key;
    Value = value;
    
  }
  public string Key { get; set; }
  public string Value { get; set; }
}