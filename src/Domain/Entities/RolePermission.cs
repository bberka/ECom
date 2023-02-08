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
    public class RolePermission : IEfEntity
	{
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [IgnoreDataMember]
        public virtual Role Role { get; set; }

        [ForeignKey("PermissionId")]
        public int PermissionId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [IgnoreDataMember]
        public virtual Permission Permission { get; set; }

    }
}
