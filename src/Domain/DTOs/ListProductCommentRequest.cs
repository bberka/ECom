namespace ECom.Domain.DTOs;

public class PageRequestWithId : PageRequest
{ 
  public int Id { get; set; }
}

public class PageRequest
{
  public ushort Page { get; set; }
}

public class PageRequestWithCulture : PageRequest
{
  [StringLength(4)]
  public string Culture { get; set; }
}
