using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductCommentViewModel
    {
        public int ProductId { get; set; }
        public ProductComment Comment { get; set; }
        public List<Image> Images { get; set; }
    }
}
