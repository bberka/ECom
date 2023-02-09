

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ECom.Domain.Entities
{
    public class Admin : IEfEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public bool IsValid { get; set; } = true;
        public bool IsTestAccount { get; set; } = false;

        [MaxLength(64)]
        [IgnoreDataMember]
        public string Password { get; set; }

        [MaxLength(ConstantMgr.EmailMaxLength)]
        [EmailAddress]
        public string EmailAddress { get; set; }


        [MaxLength(255)]
        [IgnoreDataMember]
        public string? TwoFactorKey { get; set; }

        /// <summary>
        /// 0: None
        /// 1: Email
        /// 2: Phone
        /// 3: Authy
        /// </summary>
        public byte TwoFactorType { get; set; } = 0;
        
        public int TotalLoginCount { get; set; } = 0;
        
        public DateTime? DeletedDate { get; set; }

        public int RoleId { get; set; }
        


        //virtual
        public virtual Role Role { get; set; }
        public virtual List<AdminLog> AdminLogs { get; set; }

    }
}
