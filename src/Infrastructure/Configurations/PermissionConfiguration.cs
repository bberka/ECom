using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission> 
    {

        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            //var permList = CommonLib.GetAdminOperationTypes()
            //    .Select(x => new Permission()
            //    {
            //        IsValid = true,
            //        Name = x
            //    });
            //builder.has(permList);
        }
    }
}
