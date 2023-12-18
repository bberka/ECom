namespace ECom.Foundation.DTOs.Request;

public class Request_Category_Update
{
  public Guid Id { get; set; }
  public string NameKey { get; set; } = null!;
  public string? MainCategoryNameKey { get; set; }
  public string Link { get; set; }
}