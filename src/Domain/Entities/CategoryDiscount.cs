using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class CategoryDiscount
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public DateTime RegisterDate { get; set; }

		public DateTime EndDate { get; set; }
		
		[Range(0,100)]
		public byte DiscountPercent { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
	}
}
