using ECom.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
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
		

		
		[MinLength(ConstantMgr.PasswordMinLength)]
		[MaxLength(ConstantMgr.PasswordMaxLength)]
        [Newtonsoft.Json.JsonIgnore, JsonIgnore, IgnoreDataMember]

        public string Password { get; set; }

		[MaxLength(ConstantMgr.EmailMaxLength)]
		[EmailAddress]
		public string EmailAddress { get; set; }


		public bool IsEmailVerified { get; set; } = false;
        

		[MinLength(ConstantMgr.NameMinLength)]
		[MaxLength(ConstantMgr.NameMaxLength)]
		public string FirstName { get; set; }


        [MinLength(ConstantMgr.NameMinLength)]
        [MaxLength(ConstantMgr.NameMaxLength)]
        public string LastName { get; set; }


        [MinLength(ConstantMgr.PhoneNumberMinLength)]
        [MaxLength(ConstantMgr.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public int? CitizenShipNumber { get; set; }
        public int? TaxNumber { get; set; }

        [MaxLength(512)]
        [Newtonsoft.Json.JsonIgnore, JsonIgnore, IgnoreDataMember]
        public string? OAuthKey { get; set; }

        public byte? OAuthType { get; set; }

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

        [MinLength(2)]
        [MaxLength(4)]
        public string Culture { get; set; } = ConstantMgr.DefaultCulture;



		//Virtual
		public virtual List<Address> Addresses { get; set; }
        public virtual List<Collection> Collections { get; set; }
        public virtual List<FavoriteProduct> FavoriteProducts { get; set; }
		public virtual List<Order> Orders { get; set; }
		public virtual List<ProductComment> ProductComments { get; set; }
        public virtual List<UserLog> UserLogs { get; set; }
        public virtual List<PasswordResetToken> PasswordResetTokens { get; set; }
        public virtual List<EmailVerifyToken> EmailVerifyTokens { get; set; }

        public virtual int FailedLoginCount => UserLogs?
            .Where(x => x.OperationName == "Auth.Login" && x.Rv != -1 && x.Params.Contains(EmailAddress))
            .Count() ?? 0;

        public virtual int TotalLoginCount => UserLogs?
            .Where(x => x.OperationName == "Auth.Login" && x.Rv == 0 && x.Params.Contains(EmailAddress))
            .Count() ?? 0;
    }
}
