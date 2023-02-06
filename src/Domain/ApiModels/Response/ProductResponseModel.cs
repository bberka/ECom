using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Response
{
    public class ProductResponseModel
    {
        public ProductDTO Product { get; set; }
        public List<ProductDTO> Variants { get; set; }
    }
}
