using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductCommentImageLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [ForeignKey("Image")]
        public int ImageId { get; set; }
        [Required]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
    }
}
