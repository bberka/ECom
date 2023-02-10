using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    [PrimaryKey(nameof(RoleId),nameof(PermissionId))]
    public class RolePermission : IEfEntity
	{
        public int RoleId { get; set; }
        public int PermissionId { get; set; }



        //virtual
        //ignore
        [IgnoreDataMember]
        public virtual Permission Permission { get; set; }
        //[IgnoreDataMember]
        //public virtual Role Role { get; set; }

    }
}
