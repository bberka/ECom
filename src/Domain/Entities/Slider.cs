using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Slider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [MaxLength(50)]
        public string Title { get; set; }
        
        [MaxLength(50)]
        public string Alt { get; set; }

        
        [MaxLength(50)]
        public int Order { get; set; }


        [ForeignKey("ImageId")]
        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }


        [ForeignKey("LanguageId")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

    }
}
