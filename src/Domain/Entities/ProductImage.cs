using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductImage : IEfEntity
	{
        
		[ForeignKey("ImageId")]
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

		[ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [IgnoreDataMember]
        public virtual Product Product { get; set; }
    }
}
