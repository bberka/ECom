using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public DateTime RegisterDate { get; set; }

		[Required]
		public bool IsValid { get; set; }

		public bool IsTestAccount { get; set; } = false;

		[Required]
		[MaxLength(32)]
		public string Username{ get; set; }
		
		[Required]
		[MaxLength(64)]
		public string Password { get; set; }

		[Required]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required]
		public bool IsEmailVerified { get; set; } = false;

        [Required]
        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        public int? CitizenShipNumber { get; set; }
        public int? TaxNumber { get; set; }

        [MaxLength(512)]
        public string? OAuthKey { get; set; }

        public byte? OAuthType { get; set; }

        [MaxLength(255)]
		public string? TwoFactorKey { get; set; }

        /// <summary>
        /// 0: None
        /// 1: Email
        /// 2: Phone
        /// 3: Authy
        /// </summary>
        [Required]
        public byte TwoFactorType { get; set; } = 0;


		[Required]
		public int TotalLoginCount { get; set; }
		
		[Required]
		[MaxLength(64)]
		public string? LastLoginIp { get; set; }

		[Required]
		[MaxLength(500)]
		public string? LastLoginUserAgent { get; set; }

		public DateTime? LastLoginDate { get; set; }

		[Required]
		public byte FailedPasswordCount { get; set; } = 0;

		public DateTime? LastPasswordUpdateDate { get; set; }
		public DateTime? DeletedDate { get; set; }

        [ForeignKey("PreferredLanguageId")]
        public int? PreferredLanguageId { get; set; }
        public virtual Category PreferredLanguage { get; set; }

    }
}
