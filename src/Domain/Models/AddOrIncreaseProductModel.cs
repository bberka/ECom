using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Models
{
	public class AddOrIncreaseProductModel
	{
		public int UserId { get; set; }
		public int ProductId { get; set; }
	}
}
