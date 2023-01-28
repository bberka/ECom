using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmailVerifyToken
    {
        [Key]
        [Required]
        [MaxLength(512)]
        public string Token { get; set; }
        [Required]
        public long UserNo { get; set; }
        [Required]
        [MaxLength(512)]
        public string Email { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }
    }
}
