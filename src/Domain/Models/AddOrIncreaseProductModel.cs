using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Models
{
	public class AddOrIncreaseProductModel
	{
		public int UserId { get; set; }
		public int ProductId { get; set; }
		public int Count { get; set; }
	}
}
