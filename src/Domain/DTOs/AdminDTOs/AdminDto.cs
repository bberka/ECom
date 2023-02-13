namespace ECom.Domain.DTOs.AdminDTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public byte TwoFactorType { get; set; } = 0;
        public string RoleName { get; set; }
        public string Permissions { get; set; }

    }
}
