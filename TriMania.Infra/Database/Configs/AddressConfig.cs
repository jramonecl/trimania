using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Domain.User;

namespace TriMania.Infra.Database.Configs
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.City).IsRequired().HasMaxLength(500);
            builder.Property(n => n.Neighborhood).IsRequired().HasMaxLength(500);
            builder.Property(n => n.Number).HasMaxLength(500);
            builder.Property(n => n.State).IsRequired().HasMaxLength(500);
            builder.Property(n => n.Street).IsRequired().HasMaxLength(500);
        }
    }
}
