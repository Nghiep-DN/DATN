using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Configurations
{
   
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.SeoAlias).HasMaxLength(200);
            builder.Property(x => x.SeoDescription).HasMaxLength(500);
            builder.Property(x => x.SeoTitle).HasMaxLength(200);

            builder.HasOne(l => l.Language).WithMany(ct => ct.CategoryTranslations).HasForeignKey(x => x.LanguageId);
            builder.HasOne(c => c.Category).WithMany(ct => ct.CategoryTranslations).HasForeignKey(x => x.CategoryId);

        }

        
    }
}
