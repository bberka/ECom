namespace ECom.Domain.DTOs.CategoryDto;

public class AddOrUpdateCategoryRequest : BaseAuthenticatedRequest
{
  public bool IsValid { get; set; }
  public string NameKey { get; set; }
  public string? ParentNameKey { get; set; }
  public string Name { get; set; }
  public LanguageType Language { get; set; }
}