using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ValueObjects
{
	public class ErrorResponse
	{
		public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
	}
}
