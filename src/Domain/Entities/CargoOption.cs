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
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        [Required]
        [ForeignKey("Image")]
        public int ImageId { get; set; }

        [Required]
        public int FreeShippingMinCost { get; set; }
    }
}
