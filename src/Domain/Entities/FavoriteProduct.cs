using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FavoriteProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserNo { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}
