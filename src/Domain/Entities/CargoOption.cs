using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CargoOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public bool IsValid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int FreeShippingMinCost { get; set; }


        [ForeignKey("LanguageId")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }



        [ForeignKey("ImageId")]
        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
