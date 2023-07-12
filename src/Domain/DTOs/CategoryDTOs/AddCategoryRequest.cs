namespace ECom.Domain.DTOs.CategoryDTOs;

public class AddCategoryRequest : AuthRequestModelBase
{
  public string Name { get; set; }

  public string Culture { get; set; }
}