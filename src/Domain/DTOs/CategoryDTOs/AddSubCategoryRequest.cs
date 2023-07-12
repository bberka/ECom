namespace ECom.Domain.DTOs.CategoryDTOs;

public class AddSubCategoryRequest : AuthRequestModelBase
{
  public int CategoryId { get; set; }

  public string Name { get; set; }

  public string Culture { get; set; }
}