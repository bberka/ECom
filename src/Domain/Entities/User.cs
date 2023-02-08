using ECom.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
	public class User : IEfEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public bool IsValid { get; set; } = true;

		public bool IsTestAccount { get; set; } = false;

		
		[MaxLength(ConstantMgr.PasswordMaxLength)]
		[JsonIgnore]
		public string Password { get; set; }

		[MaxLength(ConstantMgr.EmailMaxLength)]
		[EmailAddress]
		public string EmailAddress { get; set; }


		public bool IsEmailVerified { get; set; } = false;

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

		[MaxLength(ConstantMgr.NameMaxLength)]
		public string Name { get; set; }


		[MaxLength(ConstantMgr.NameMaxLength)]
		public string Surname { get; set; }

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
        public byte TwoFactorType { get; set; } = 0;

        public int TotalLoginCount { get; set; } = 0;
		
		[MaxLength(64)]
		public string? LastLoginIp { get; set; }

		[MaxLength(500)]
		public string? LastLoginUserAgent { get; set; }

		public DateTime? LastLoginDate { get; set; }

		public int FailedPasswordCount { get; set; } = 0;

		public DateTime? PasswordLastUpdateDate { get; set; }
		public DateTime? DeletedDate { get; set; }

        [MinLength(2)]
        [MaxLength(4)]
        public string Culture { get; set; } = ConstantMgr.DefaultCulture;

		public virtual List<Address> Addresses { get; set; }
        public virtual List<Collection> Collections { get; set; }
        public virtual List<FavoriteProduct> FavoriteProducts { get; set; }
		public virtual List<Order> Orders { get; set; }
		public virtual List<ProductComment> ProductComments { get; set; }
		//public virtual List<ProductCommentStar> ProductCommentStars { get; set; }




    }
}
