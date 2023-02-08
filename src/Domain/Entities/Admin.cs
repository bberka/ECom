﻿

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
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string Password { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string EmailAddress { get; set; }


        [MaxLength(255)]
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string? TwoFactorKey { get; set; }

        /// <summary>
        /// 0: None
        /// 1: Email
        /// 2: Phone
        /// 3: Authy
        /// </summary>
        public byte TwoFactorType { get; set; } = 0;


        public int TotalLoginCount { get; set; } = 0;

        [MaxLength(64)]
        public string? LastLoginIp { get; set; }
        
        [MaxLength(500)]
        public string? LastLoginUserAgent { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public byte FailedPasswordCount { get; set; } = 0;
        public DateTime? PasswordLastUpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }


        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
