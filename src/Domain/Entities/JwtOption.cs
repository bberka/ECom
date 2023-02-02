using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
	public class JwtOption : IEfEntity
	{
		/// <summary>
		/// 0: Debug
		/// 1: Release
		/// </summary>
		[Key]
		public bool IsRelease { get; set; }

		[MaxLength(512)]
		public string Secret { get; set; }

		public bool ValidateAudience { get =>  Audience != null;  } 

		[MaxLength(128)]
		public string? Audience { get; set; }

		public bool ValidateIssuer { get => Issuer != null; }

		[MaxLength(128)]
		public string? Issuer { get; set; }

		public int ExpireMinutesDefault { get; set; }

		public int ExpireMinutesLong { get; set; }

		public bool IsUseRefreshToken { get; set; }
	}
}
