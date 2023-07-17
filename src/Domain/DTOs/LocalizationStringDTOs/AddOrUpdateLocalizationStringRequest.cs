namespace ECom.Domain.DTOs.LocalizationStringDTOs;

public class AddOrUpdateLocalizationStringRequest : BaseAuthenticatedRequest
{
  public string NameKey { get; set; }
  public string? ParentNameKey { get; set; }
  public string Name { get; set; }
  public LanguageType Language { get; set; }
  
}