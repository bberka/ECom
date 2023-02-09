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
    [PrimaryKey(nameof(ImageId),nameof(ProductCommentId))]
    public class ProductCommentImage : IEfEntity
	{
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        
        public int ImageId { get; set; }
        public int ProductCommentId { get; set; }


        //Virtual
        //Ignore
        [IgnoreDataMember]
        public virtual ProductComment ProductComment { get; set; }
        [IgnoreDataMember]
        public virtual Image Image { get; set; }


    }
}
