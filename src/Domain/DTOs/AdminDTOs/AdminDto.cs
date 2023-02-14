namespace ECom.Domain.DTOs.AdminDTOs
{
    public class AdminDto
    {
        public AdminDto()
        {

        }
        public int Id { get; init; }
        public string EmailAddress { get; init; }
        public byte TwoFactorType { get; init; } = 0;

        [NotMapped]
        public string RoleName { get; init; }
        
        [NotMapped]
        public string Permissions { get; init; }
        public int RoleId { get; init; }
        
        public static AdminDto FromEntity(Admin admin)
        {
            return new AdminDto
            {
                Id = admin.Id,
                EmailAddress = admin.EmailAddress,
                TwoFactorType = admin.TwoFactorType,
                Permissions = string.Join(",", admin.Role.Permissions.Select(x => x.Name).ToArray()),
                RoleName = admin.Role.Name,
                RoleId = admin.Role.Id
            };
        }
        
        public Admin ToEntity()
        {
            return new Admin()
            {
                EmailAddress = EmailAddress,
                TwoFactorType = TwoFactorType,
                Id = Id,
                RoleId = RoleId,
            };
        }

      
    }
}
