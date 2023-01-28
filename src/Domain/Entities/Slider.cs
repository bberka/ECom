using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Slider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Alt { get; set; }

        [Required]
        [MaxLength(50)]
        public int Order { get; set; }

        [Required]
        [ForeignKey("Image")]
        public int ImageId { get; set; }

        [Required]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

    }
}
