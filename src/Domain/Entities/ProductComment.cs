using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        
        public DateTime RegisterDate { get; set; }

        public DateTime? DeletedDate { get; set; }
        
        [MaxLength(64)]
        public string Title { get; set; }
        
        [MaxLength(1000)]
        public string Description { get; set; }


        [Range(0,5)]
        public byte Star { get; set; }


        [ForeignKey("AuthorUserId")]
        public int? AuthorUserId { get; set; }
        public virtual User AuthorUser { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
