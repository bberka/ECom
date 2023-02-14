using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Role : IEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(ConstantMgr.NameMinLength)]
        [MaxLength(ConstantMgr.NameMaxLength)]
        public string Name { get; set; }

        public bool IsValid { get; set; } = true;

        //Virtual
        public virtual HashSet<Permission> Permissions { get; set; } 

    }
}
