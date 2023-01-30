using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductView
    {
        public Product Product { get; set; }
        public List<Product> ProductVariants { get; set; }
        public ProductDetails Details { get; set; }
        public List<ProductDiscount> ActiveDiscounts { get; set; }
        public List<ProductCommentViewModel> Comments { get; set; }
    }
}
