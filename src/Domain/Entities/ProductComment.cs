using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductComment : IEfEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        
        public DateTime RegisterDate { get; set; }
        
        
        [MaxLength(64)]
        public string Title { get; set; }
        
        [MaxLength(1000)]
        public string Description { get; set; }


        [ForeignKey("AuthorUserId")]
        public int AuthorUserId { get; set; }
        public virtual User? AuthorUser { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Product? Product { get; set; }

        public virtual List<ProductCommentImage> Images { get; set; }
        public virtual List<ProductCommentStar> Stars { get; set; }

        public virtual double StarScore => Stars.Average(x => x.Star);

    }
}
