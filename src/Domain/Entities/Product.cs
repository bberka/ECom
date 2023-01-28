using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		[Required]
		public DateTime RegisterDate { get; set; }

		public DateTime? DeleteDate { get; set; }
		public DateTime? StockEndDate { get; set; }

		public bool IsLimited { get; set; }


		[MaxLength(1000)]
		public string? ImageIds { get; set; }

		[Required]
		[Range(0, 1_000_000_000)]
		public int SoldCount { get; set; }

		[Required]
		[Range(0, 1_000_000_000)]
		public int StockCount { get; set; }

		[Required]
		[Range(0, 1_000_000_000)]
		public int Price { get; set; }



    }
}
