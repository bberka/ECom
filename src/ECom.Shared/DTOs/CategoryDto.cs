namespace ECom.Shared.DTOs;

public class CategoryDto
{
  public int Order { get; set; }

  public string NameKey { get; set; }

  public List<CategoryDto> Categories { get; set; } = new();
}