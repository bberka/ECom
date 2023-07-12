namespace ECom.Domain.DTOs.CategoryDTOs;

public class UpdateCategoryRequest : AuthRequestModelBase
{
  public int CategoryId { get; set; }
  public string Name { get; set; }
  public string Culture { get; set; }
  public bool IsValid { get; set; }
}