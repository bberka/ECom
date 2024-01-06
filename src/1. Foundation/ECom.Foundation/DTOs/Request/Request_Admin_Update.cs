using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public class Request_Admin_Update : BaseAuthenticatedRequest
{
  [Required]
  public Guid Id { get; set; }

  [EmailAddress]
  [Required]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  public string EmailAddress { get; set; }

  [Required]
  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string RoleId { get; set; }

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