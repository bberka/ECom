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
            //builder.HasData(_roles);
        }

        private static readonly List<Role> _roles = new()
        {
            new Role()
            {
                IsValid = true,
                Name = "Owner",
            },
            new Role()
            {
                IsValid = true,
                Name = "Admin",
            },
            new Role()
            {
                IsValid = true,
                Name = "Moderator",
            },
        };

    }
}
