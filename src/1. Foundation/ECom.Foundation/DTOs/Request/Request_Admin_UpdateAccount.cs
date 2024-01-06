using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public class Request_Admin_UpdateAccount : BaseAuthenticatedRequest
{
  [EmailAddress]
  [Required]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  public string EmailAddress { get; set; }

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string FirstName { get; set; }

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string LastName { get; set; }

  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  public string PhoneNumber { get; set; }
}