using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Abstract
{
	public interface ILocalization
	{
		public string Get(string key);
	}
}
