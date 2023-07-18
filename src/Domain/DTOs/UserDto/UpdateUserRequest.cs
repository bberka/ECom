namespace ECom.Domain.DTOs.UserDto;

public class UpdateUserRequest : BaseAuthenticatedRequest
{
  public string EmailAddress { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string PhoneNumber { get; set; }
  public int? CitizenShipNumber { get; set; }
  public int? TaxNumber { get; set; }
}