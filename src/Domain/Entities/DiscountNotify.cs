using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DiscountNotify
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; } 


        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
