using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class EmailVerifyToken : IEfEntity
	{
        [Key]
        
        [MaxLength(512)]
        public string Token { get; set; }
        
        [MaxLength(ConstantMgr.EmailMaxLength)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public bool IsUsed { get; set; } = false;

        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; } 

        public int UserId { get; set; }



        //virtual
        public virtual User User { get; set; }

    }
}
