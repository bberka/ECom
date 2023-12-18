namespace ECom.Foundation.DTOs.Request;

public class Request_ProductComment_Add : BaseAuthenticatedRequest
{
  public string Comment { get; set; }

  public byte Star { get; set; }

  public Guid ProductId { get; set; }
}