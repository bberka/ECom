namespace ECom.Foundation.DTOs;

public class CategoryDto
{
  public Guid Id { get; set; }
  public int Order { get; set; }
  public string NameKey { get; set; }
  public string? MainCategoryNameKey { get; set; }
  public string Link { get; set; }
  public List<CategoryDto> Categories { get; set; } = new();

  public bool ShouldContainProduct => MainCategoryNameKey is not null && Categories.Count == 0;
}