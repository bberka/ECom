using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductDetail : IEfEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        
        [MaxLength(512)]
        [MinLength(8)]
        public string ShortDescription { get; set; }

        
        [MaxLength(10000)]
        [MinLength(64)]
        public string DescriptionHTML { get; set; }

        [MaxLength(10000)]
        [MinLength(64)]
        public string? TechnicalInformationHTML { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [ForeignKey("Culture")]
        public string? Culture { get; set; }
        public virtual Language? Language { get; set; }


    }
}
