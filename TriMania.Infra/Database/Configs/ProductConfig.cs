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
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Name).IsRequired().HasMaxLength(250);
            builder.Property(n => n.Price).IsRequired();
        }
    }
}
