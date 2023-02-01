using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Extensions
{
	public static class EnumExtensions
	{
		public static Response ToResponseEnum(this object? value)
		{
			var res = Enum.TryParse(typeof(Response), value?.ToString(), out var outValue);
			if (!res || outValue is null) return Response.None;
			return (Response)outValue;
		}
	}
}
