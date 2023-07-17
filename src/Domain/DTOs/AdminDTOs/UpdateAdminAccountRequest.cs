namespace ECom.Domain.DTOs.AdminDTOs;

public class UpdateAdminAccountRequest : BaseAuthenticatedRequest
{
  public string EmailAddress { get; set; }
}