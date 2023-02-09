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
        public bool IsRelease { get; set; } = true;
        public bool IsOpen { get; set; } = true;
        public bool IsAdminOpen { get; set; } = true;
        public byte PagingProductCount { get; set; } = 20;
        public bool RequireUpperCaseInPassword { get; set; } = false;
        public bool RequireLowerCaseInPassword { get; set; } = false;
        public bool RequireSpecialCharacterInPassword { get; set; } = false;
        public bool RequireNumberInPassword { get; set; } = false;

        [Range(15, 43200)]
        public int EmailVerificationTimeoutMinutes { get; set; } = 30;

		[Range(15, 43200)]
		public int PasswordResetTimeoutMinutes { get; set; } = 30;

        [MaxLength(12)]
        public string SelectedCurrency { get; set; } = "TL";
        public bool ShowStock { get; set; } = false;
        public byte ProductImageLimit { get; set; } = 10;
        public byte ProductCommentImageLimit { get; set; } = 5;



    }
}
