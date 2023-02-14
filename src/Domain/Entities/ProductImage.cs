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
    [PrimaryKey(nameof(ImageId),nameof(ProductId))]
    public class ProductImage : IEntity
	{
        [ForeignKey(nameof(Image))]
        public int ImageId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

    }
}
