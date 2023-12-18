namespace ECom.Foundation.DTOs.Request;

public class Request_User_Update : BaseAuthenticatedRequest
{
  public string EmailAddress { get; set; } = null!;
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string PhoneNumber { get; set; } = null!;
  public int? CitizenShipNumber { get; set; }
}