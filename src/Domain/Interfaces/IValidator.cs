using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IValidator<T> where T : unmanaged
	{
		public bool Validate(T input);
	}
}
