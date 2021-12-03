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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.CreationDate).IsRequired();
            builder.Property(n => n.Status).IsRequired();
            builder.Ignore(n => n.TotalValue);

            builder.HasOne(n => n.User).WithMany().HasForeignKey(n => n.UserId);
            builder.HasMany(n => n.Items);
        }
    }
}
