namespace ECom.Shared.DTOs;

public class GetAdminRequest : BaseAuthenticatedRequest
{
    public int Id { get; set; }
}