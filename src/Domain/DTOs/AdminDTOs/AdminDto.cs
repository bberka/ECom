namespace ECom.Domain.DTOs.AdminDTOs
{
    public class AdminDto
    {
        public AdminDto()
        {

        }
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public byte TwoFactorType { get; set; } = 0;
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public string[] Permissions { get; set; }


        public string GetPermissionsString()
        {
            return string.Join(",", Permissions);
        }
        public static AdminDto FromEntity(Admin admin)
        {
            return new AdminDto
            {
                Id = admin.Id,
                EmailAddress = admin.EmailAddress,
                TwoFactorType = admin.TwoFactorType,
                //Permissions = string.Join(",", admin.Role.Permissions.Select(x => x.Name).ToArray()),
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
