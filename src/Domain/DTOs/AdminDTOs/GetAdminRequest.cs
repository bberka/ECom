using Microsoft.AspNetCore.Mvc;

namespace ECom.Domain.DTOs.AdminDTOs;

public class GetAdminRequest : BaseAuthenticatedRequest
{
  [FromQuery(Name = "id")]
  public int Id { get; set; }
}