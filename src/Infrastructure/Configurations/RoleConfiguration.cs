using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role> 
    {

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Navigation(x => x.PermissionRoles).AutoInclude();

        }

        

    }
}
