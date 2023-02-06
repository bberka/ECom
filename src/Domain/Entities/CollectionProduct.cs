using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class CollectionProduct : IEfEntity
	{
        public DateTime RegisterDate { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("CollectionId")]
        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
