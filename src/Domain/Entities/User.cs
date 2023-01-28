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
		/// 0: Email
		/// 1: Phone
		/// 2: Authy
		/// </summary>
        public byte? TwoFactorType { get; set; }

		[Required]
		public bool IsEnabledTwoFactor { get; set; } = false;

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

        [Required]
        [MaxLength(6)]
        public string? PreferredLanguage { get; set; }

        [Required]
		[ForeignKey("Address")]
        public int LastShippingAddressId { get; set; }
        [Required]
        [ForeignKey("Address")]
        public int LastBillingAddressId { get; set; }
    }
}
