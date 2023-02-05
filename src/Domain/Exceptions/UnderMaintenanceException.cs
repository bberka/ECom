using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
	public class UnderMaintenanceException : CustomException
	{
		public UnderMaintenanceException() : base(ErrCode.UnderMaintenance.ToString())
		{

		}
	}
}
