namespace ECom.Domain.DTOs.CategoryDTOs;

public class AddOrUpdateCategoryRequest : BaseAuthenticatedRequest
{
  public string NameKey { get; set; }
  public string? ParentNameKey { get; set; }
  public string Name { get; set; }
  public LanguageType Language { get; set; }
}