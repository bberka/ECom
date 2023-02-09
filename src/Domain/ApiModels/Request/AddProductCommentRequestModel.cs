using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.ApiModels.Request
{
    public class AddProductCommentRequestModel : AuthRequestModelBase
    {
        [MaxLength(1000)]
        [MinLength(8)]
        public string Comment { get; set; }

        public byte Star { get; set; }

        public int ProductId { get; set; }

    }

}
