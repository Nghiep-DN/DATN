using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(); //.IsUnicode(false)

            builder.HasOne(p => p.Product).WithMany(pt => pt.ProductTranslations).HasForeignKey(x => x.ProductId);
            builder.HasOne(p => p.Language).WithMany(pt => pt.ProductTranslations).HasForeignKey(x => x.LanguageId);
        }
    }   
}
