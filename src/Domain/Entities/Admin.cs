using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasMe.EFCore;
namespace ECom.Domain.Entities
{
    public class Admin : IEfEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool IsValid { get; set; }
        public bool IsTestAccount { get; set; } = false;


        [MaxLength(64)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string EmailAddress { get; set; }

        public bool IsEmailVerified { get; set; } = false;

        [MaxLength(255)]
        public string? TwoFactorKey { get; set; }

        /// <summary>
        /// 0: None
        /// 1: Email
        /// 2: Phone
        /// 3: Authy
        /// </summary>
        public byte TwoFactorType { get; set; } = 0;
        

        public int TotalLoginCount { get; set; }

        [MaxLength(64)]
        public string? LastLoginIp { get; set; }
        
        [MaxLength(500)]
        public string? LastLoginUserAgent { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public byte FailedPasswordCount { get; set; } = 0;
        public DateTime? LastPasswordUpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        [ForeignKey("RoleId")]
        public int? RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public List<Permission> Permissions { get; set; }

    }
}
