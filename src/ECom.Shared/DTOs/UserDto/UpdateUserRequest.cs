namespace ECom.Shared.DTOs.UserDto;

public class UpdateUserRequest : BaseAuthenticatedRequest
{
  public string EmailAddress { get; set; } = null!;
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string PhoneNumber { get; set; } = null!;
  public int? CitizenShipNumber { get; set; }
  public int? TaxNumber { get; set; }
}