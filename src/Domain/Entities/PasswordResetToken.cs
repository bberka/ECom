using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class PasswordResetToken : IEfEntity
	{
        [Key]
        
        [MaxLength(512)]
        public string Token { get; set; }

        
        public bool IsUsed { get; set; }

        
        public DateTime RegisterDate { get; set; }

        
        public DateTime ExpireDate { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

    }
}
