using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Extensions
{
	public static class ObjectExtensions
	{
		public static void CheckNullOrThrow(this object? obj)
		{
			if(obj == null) throw new ArgumentNullException(nameof(obj)); 
		}
		public static void CheckNullOrThrow(this object? obj,string msg)
		{
			if (obj == null) throw new ArgumentNullException(msg);
		}
	}
}
