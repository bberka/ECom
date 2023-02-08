using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductCommentStar : IEfEntity
    {
        public byte Star { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User User { get; set; }
        
        [ForeignKey("CommentId")]
        public int CommentId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ProductComment Comment { get; set; }
    }
}
