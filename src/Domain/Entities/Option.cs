using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Option : IEntity
	{
        [Key]
        
        public bool IsOpen { get; set; }
        
        public bool IsMaintenance { get; set; }
        
        public bool IsDebug { get; set; }
        
        [MaxLength(512)]
        public string JwtSecret { get; set; }

        public bool JwtValidateAudience { get; set; }
        [MaxLength(128)]
        public string? JwtAudience { get; set; }

        public bool JwtValidateIssuer { get; set; }

        [MaxLength(128)]
        public string? JwtIssuer { get; set; }
        
        public int JwtExpireMinutesDefault { get; set; }
        
        public int JwtExpireMinutesLong { get; set; }

        [MaxLength(512)]
        public string JwtSecret_Admin { get; set; }

        public bool IsUseRefreshToken { get; set; }
        
        public byte PagingProductCount { get; set; }
        
        public byte UsernameMinLength { get; set; }
        
        public byte PasswordMinLength { get; set; }
        
        public bool RequireUpperCaseInPassword { get; set; }
        
        public bool RequireLowerCaseInPassword { get; set; }
        
        public bool RequireSpecialCharacterInPassword { get; set; }
        
        public bool RequireNumberInPassword { get; set; }

        [MaxLength(128)]
        public string? AllowedSpecialCharactersInUsername { get; set; }
        [MaxLength(128)]
        public string? AllowedSpecialCharactersInPassword { get; set; }

        
        [MaxLength(128)]
        public string DomainUrl { get; set; }
        
        [MaxLength(128)]
        public string WebApiUrl { get; set; }

        
        [Range(15, 43200)]
        public int EmailVerificationTimeoutMinutes { get; set; }

        
        [MaxLength(16)]
        public string Currency { get; set; }



        
        [MaxLength(128)]
        public string CompanyName { get; set; }
        public string Description { get; set; }



        public int? PhoneNumber { get; set; }

        
        [MaxLength(255)]
        public string ContactEmail { get; set; }

        public int? WhatsApp { get; set; }


        
        [MaxLength(255)]
        public string CompanyAddress { get; set; }

        [MaxLength(255)]
        public string? FacebookLink { get; set; }
        [MaxLength(255)]
        public string? InstagramLink { get; set; }
        [MaxLength(255)]
        public string? YoutubeLink { get; set; }

        
        public bool ShowStock { get; set; }

        public byte ProductImageLimit { get; set; }
        public byte ProductCommentImageLimit { get; set; }

        [ForeignKey("DefaultLanguageId")]
        public int? DefaultLanguageId { get; set; }
        public virtual Language DefaultLanguage { get; set; }


        [ForeignKey("LogoImageId")]
        public int? LogoImageId { get; set; }
        public virtual Image LogoImage { get; set; }

        [ForeignKey("FavIcoImageId")]
        public int? FavIcoImageId { get; set; }
        public virtual Image FavIcoImage { get; set; }

    }
}
