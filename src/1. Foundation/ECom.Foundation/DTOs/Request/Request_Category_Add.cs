namespace ECom.Foundation.DTOs.Request;

public class Request_Category_Add
{
  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  [Required]
  public string NameKey { get; set; }

  public string? MainCategoryNameKey { get; set; }

  [MaxLength(ConstantContainer.MaxNameLength)]
  [Required]
  public string Link { get; set; }
}