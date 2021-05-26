using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)

        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(p => p.Product).WithMany(c => c.Carts).HasForeignKey(x => x.ProductId);
            builder.HasOne(a => a.AppUser).WithMany(c => c.Carts).HasForeignKey(x => x.UserId);
           
        }
    }
}
