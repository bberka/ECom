namespace ECom.Shared.DTOs;

public class PageRequestDtoWithId : PageRequestDto
{
  public Guid Id { get; set; }
}

public class PageRequestDto
{
  public ushort Page { get; set; }
}

public class PageRequestDtoWithCulture : PageRequestDto
{
  [StringLength(4)]
  public string Culture { get; set; }
}
