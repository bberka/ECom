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
    public class RolePermission : IEntity
	{
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        [ForeignKey(nameof(Permission))]
        public int PermissionId { get; set; }
    }
}
