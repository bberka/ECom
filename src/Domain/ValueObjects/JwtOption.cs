using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ValueObjects
{
    public class JwtOption
    {
		private JwtOption() 
		{
			Secret = ConfigHelper.GetString("JwtSecret") ?? throw new NullException(nameof(Secret));
            Issuer = ConfigHelper.GetString("JwtIssuer");
            Audience = ConfigHelper.GetString("JwtAudience");
            TokenExpireMinutes = ConfigHelper.Get<int>("JwtTokenExpireMinutes");
        }
        public static JwtOption This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static JwtOption? Instance;

		public string Secret { get; set; }
		public string? Issuer { get; set; }
		public bool ValidateIssuer { get => Issuer != null ; }
		public string? Audience { get; set; }
        public bool ValidateAudience { get => Audience != null; }
		public int TokenExpireMinutes { get; set; } = 10080;
	}
}
