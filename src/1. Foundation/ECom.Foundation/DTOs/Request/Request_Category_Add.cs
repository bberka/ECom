using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public class Request_Category_Add
{
  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  [Required]
  public string NameKey { get; set; }

  public string? MainCategoryNameKey { get; set; }

  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  [Required]
  public string Link { get; set; }
}