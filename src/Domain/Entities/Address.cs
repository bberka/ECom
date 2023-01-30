using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }


        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        [MaxLength(64)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
        [Required]
        [MaxLength(64)]
        public string Town { get; set; }
        [Required]
        [MaxLength(64)]
        public string Country { get; set; }
        public string Provience { get; set; }
        [Required]
        [MaxLength(64)]
        public string Details { get; set; }
        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public bool IsPreferred { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }



    }
}
