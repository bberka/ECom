using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(512)]
        public string Description { get; set; }

        [Required]
        [MaxLength(5000)]
        public string DescriptionHTML { get; set; }

        [MaxLength(5000)]
        public string? TechnicalInformationHTML { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("LanguageId")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }


    }
}
