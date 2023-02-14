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
            //var permEnumList = CommonLib.GetAdminOperationTypes();
            //var permList  = new List<Permission>();
            //for (int i = 1; i < permEnumList.Length; i++)
            //{
            //    var str = permEnumList[i];
            //    permList.Add(new Permission()
            //    {
            //        Id = i,
            //        IsValid = true,
            //        Name = str
            //    });
            //}
            //builder.HasData(permList);
        }
    }
}
