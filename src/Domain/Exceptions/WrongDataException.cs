using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
	public class WrongDataException : CustomException
	{
		public WrongDataException(string name) : base(name)
		{

		}
	}
}
