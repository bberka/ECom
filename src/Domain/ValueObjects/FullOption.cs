using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ValueObjects
{
	public class FullOption
	{
		public Option Option { get; set; }
		public JwtOption JwtOption { get; set; }
		public List<SmtpOption> SmtpOptions { get; set; }
		public List<CargoOption> CargoOptions { get; set; }
		public List<PaymentOption> PaymentOptions { get; set; }
	}
}
