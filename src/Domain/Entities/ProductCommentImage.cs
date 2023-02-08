using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductCommentImage : IEfEntity
	{

        [ForeignKey("ImageId")]
        public int ImageId { get; set; }

        [IgnoreDataMember]
        public virtual Image Image { get; set; }

        [ForeignKey("CommentId")]
        public int CommentId { get; set; }

        [IgnoreDataMember]
        public virtual ProductComment? Comment { get; set; }


    }
}
