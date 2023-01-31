using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Interfaces
{
	public interface ILocalization
	{
		public string Get(string key);
	}
}
