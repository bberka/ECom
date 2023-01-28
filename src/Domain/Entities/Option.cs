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
        public byte Key { get; set; }
        [Required]
        public bool IsOpen { get; set; }
        [Required]
        public bool IsMaintenance { get; set; }
        [Required]
        public bool IsDebug { get; set; }
        [Required]
        public string JwtSecret { get; set; }
        public string? JwtAudience { get; set; }
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
        public byte UsernameMaxLength { get; set; }
        [Required]
        public byte PasswordMinLength { get; set; }
        [Required]
        public byte PasswordMaxLength { get; set; }
        [Required]
        public bool RequireStrongPassword { get; set; }
       

    }
}
