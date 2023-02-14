

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ECom.Domain.Entities
{
    public class Admin : IEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public bool IsValid { get; set; } = true;


        [MaxLength(64)]
        [Newtonsoft.Json.JsonIgnore,JsonIgnore,IgnoreDataMember]
        public string Password { get; set; }

        [MaxLength(ConstantMgr.EmailMaxLength)]
        [EmailAddress]
        public string EmailAddress { get; set; }


        [MaxLength(255)]
        [Newtonsoft.Json.JsonIgnore, JsonIgnore, IgnoreDataMember]
        public string? TwoFactorKey { get; set; }

        /// <summary>
        /// 0: None
        /// 1: Email
        /// 2: Phone
        /// 3: Authy
        /// </summary>
        public byte TwoFactorType { get; set; } = 0;
        
        
        public DateTime? DeletedDate { get; set; }

        public int RoleId { get; set; }
        

        //virtual
        public virtual Role Role { get; set; }
        public virtual HashSet<AdminLog> AdminLogs { get; set; }

    }
}
