using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Configurations
{

    //trung gian giua 2 bang product va category (2 khoa ngoai toi 2 bang)
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(x => new { x.CategoryId, x.ProductId });

            //lien ket 1 nhieu giua product va ProductInCategories 
            //HasForeignKey(pc => pc.ProductId) => khoa ngoai la ProductId
            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.ProductId);

            builder.HasOne(t => t.Category).WithMany(pc => pc.ProductInCategories).HasForeignKey(pc => pc.CategoryId);
        }
    }
}
