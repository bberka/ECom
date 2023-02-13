namespace ECom.Domain.DTOs.AdminDTOs
{
    public class UpdateAdminAccountRequest : AuthRequestModelBase
    {
        public string EmailAddress { get; set; }
    }
}
