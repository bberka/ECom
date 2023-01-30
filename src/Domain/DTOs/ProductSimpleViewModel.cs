using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductSimpleViewModel
    {
        public Product Product { get; set; }
        public ProductDetails Details { get; set; }
    }
}
