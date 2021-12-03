using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Domain.Shopping;

namespace TriMania.Infra.Database.Configs
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Price).IsRequired();
            builder.Property(n => n.Quantity).IsRequired();

            builder.HasOne(n => n.Product).WithMany().HasForeignKey(n => n.ProductId);
        }
    }
}
