using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    [PrimaryKey(nameof(ProductId),nameof(CollectionId))]
    public class CollectionProduct : IEntity
	{
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public int CollectionId { get; set; }


        //virtual
        public virtual Product Product { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
