using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    [PrimaryKey(nameof(ProductId),nameof(SubCategoryId))]
    public class ProductSubCategory : IEntity
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        
        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }

    }
}
