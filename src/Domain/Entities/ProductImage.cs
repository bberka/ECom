﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductImage : IEfEntity
	{
        
		[ForeignKey("ImageId")]
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

		[ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Product? Product { get; set; }
    }
}
