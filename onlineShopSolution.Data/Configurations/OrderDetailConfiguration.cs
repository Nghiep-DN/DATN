using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Configurations
{
    // lien ket n 1 voi bang Order
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
           builder.ToTable("OrderDetails");
           builder.HasKey(x => new { x.OrderId,x.ProductId });

            //chi can cau hinh so nhieu, so it la order thi ko can
           builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);

           builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId);
        }
    }
}
