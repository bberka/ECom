﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductCommentImage : IEfEntity
	{

        [ForeignKey("ImageId")]
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

        [ForeignKey("CommentId")]
        public int CommentId { get; set; }
        public virtual ProductComment Comment { get; set; }


    }
}