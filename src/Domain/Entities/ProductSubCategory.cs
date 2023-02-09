using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    [PrimaryKey(nameof(ProductId),nameof(SubCategoryId))]
    public class ProductSubCategory : IEfEntity
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("SubCategoryId")]
        public int SubCategoryId { get; set; }



        //Virtual
        public virtual SubCategory SubCategory { get; set; }
        public virtual Product Product { get; set; }

    }
}
