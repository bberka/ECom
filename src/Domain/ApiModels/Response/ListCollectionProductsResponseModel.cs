using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Response
{
    public class ListCollectionProductsResponseModel
    {
        public Collection Collection { get; set; } = new();
        public List<ProductDTO> Products { get; set; } = new();
    }
}
