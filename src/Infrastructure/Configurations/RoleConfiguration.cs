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
            builder.HasData(_roles);
        }

        private static readonly List<Role> _roles = new()
        {
            new Role()
            {
                IsValid = true,
                Name = "Owner",
                Id = 1
            },
            new Role()
            {
                IsValid = true,
                Name = "Admin",
                Id = 2
            },
            new Role()
            {
                IsValid = true,
                Name = "Moderator",
                Id = 3
            },
        };

    }
}
