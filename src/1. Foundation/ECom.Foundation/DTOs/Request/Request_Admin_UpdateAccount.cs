namespace ECom.Foundation.DTOs.Request;

public class Request_Admin_UpdateAccount : BaseAuthenticatedRequest
{
  [Required]
  public Guid Id { get; set; }

  [EmailAddress]
  [Required]
  [MaxLength(ConstantContainer.MaxEmailLength)]
  public string EmailAddress { get; set; }

  [Required]
  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string RoleId { get; set; }
}