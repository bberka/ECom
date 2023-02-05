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
			TokenExpireDefaultMinutes = ConfigHelper.Get<int>("JwtTokenExpireDefaultMinutes");
            TokenExpireLongMinutes = ConfigHelper.Get<int>("JwtTokenExpireLongMinutes");
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
		public string? Audience { get; set; }
		public int TokenExpireDefaultMinutes { get; set; } = 10;
		public int TokenExpireLongMinutes { get; set; } = 10080;
	}
}
