using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Option
    {
        [Key]
        [Required]
        public bool IsOpen { get; set; }
        [Required]
        public bool IsMaintenance { get; set; }
        [Required]
        public bool IsDebug { get; set; }
        [Required]
        [MaxLength(512)]
        public string JwtSecret { get; set; }
        [MaxLength(128)]
        public string? JwtAudience { get; set; }
        [MaxLength(128)]
        public string? JwtIssuer { get; set; }
        [Required]
        public int JwtExpireMinutesDefault { get; set; }
        [Required]
        public int JwtExpireMinutesLong { get; set; }
        [Required]
        public bool IsUseRefreshToken { get; set; }
        [Required]
        public byte PagingProductCount { get; set; }
        [Required]
        public byte UsernameMinLength { get; set; }
        [Required]
        public byte PasswordMinLength { get; set; }
        [Required]
        public bool RequireUpperCaseInPassword { get; set; }
        [Required]
        public bool RequireLowerCaseInPassword { get; set; }
        [Required]
        public bool RequireSpecialCharacterInPassword { get; set; }
        [Required]
        public bool RequireNumberInPassword { get; set; }

        [MaxLength(128)]
        public string? AllowedSpecialCharactersInUsername { get; set; }
        [MaxLength(128)]
        public string? AllowedSpecialCharactersInPassword { get; set; }

        [Required]
        [MaxLength(128)]
        public string DomainUrl { get; set; }
        [Required]
        [MaxLength(128)]
        public string WebApiUrl { get; set; }

        [Required]
        [Range(15,43200)]
        public int EmailVerificationTimeoutMinutes { get; set; }

        
    }
}
