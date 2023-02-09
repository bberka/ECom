using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations
{
    public class ProductCommentStarConfiguration : IEntityTypeConfiguration<ProductCommentStar>
    {
        public void Configure(EntityTypeBuilder<ProductCommentStar> builder)
        {
            //builder
            //    .HasOne<ProductComment>()
            //    .WithMany()
            //    .HasForeignKey(x => x.ProductCommentId)
            //    .OnDelete(DeleteBehavior.Restrict);


            //builder.HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
