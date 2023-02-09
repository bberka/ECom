using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations
{
    public class ProductCommentConfiguration : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            //builder
            //    .HasMany<ProductCommentStar>()
            //    .WithOne()
            //    .HasForeignKey(x => x.ProductCommentId)
            //    .OnDelete(DeleteBehavior.Restrict);


            //builder.HasOne<Product>()
            //    .WithMany()
            //    .HasForeignKey(x => x.ProductId)
            //    .OnDelete(DeleteBehavior.Restrict);


            ////builder.HasOne<User>()
            ////    .WithMany()
            ////    .HasForeignKey(x => x.ProductId)
            ////    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
