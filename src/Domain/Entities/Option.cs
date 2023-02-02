using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Option : IEfEntity
	{
        [Key]
		public bool IsRelease { get; set; }
        public bool IsOpen { get; set; }
        public bool IsAdminOpen { get; set; }
        public byte PagingProductCount { get; set; }
        public byte UsernameMinLength { get; set; }
        public byte PasswordMinLength { get; set; }
        public bool RequireUpperCaseInPassword { get; set; }
        public bool RequireLowerCaseInPassword { get; set; }
        public bool RequireSpecialCharacterInPassword { get; set; }
        public bool RequireNumberInPassword { get; set; }
        
        [Range(15, 43200)]
        public int EmailVerificationTimeoutMinutes { get; set; }

		[Range(15, 43200)]
		public int PasswordResetTimeoutMinutes { get; set; }

		[MaxLength(16)]
        public string SelectedCurrency { get; set; }

        public bool ShowStock { get; set; }
        public byte ProductImageLimit { get; set; }
        public byte ProductCommentImageLimit { get; set; }



    }
}
