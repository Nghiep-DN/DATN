using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShopSolution.Data.Entities;

namespace onlineShopSolution.Data.Configurations
{
    //cach validate
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            //ten table trong csdl
            builder.ToTable("AppConfigs");
            //key
            builder.HasKey(x => x.Key);
            //value bat buoc nhap vao
            builder.Property(x => x.Value).IsRequired(true);
        }
    }
       
}
