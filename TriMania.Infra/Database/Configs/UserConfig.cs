using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriMania.Domain.User;

namespace TriMania.Infra.Database.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(n => n.Email).IsRequired().HasMaxLength(300);
            builder.Property(n => n.Login).IsRequired().HasMaxLength(300);
            builder.Property(n => n.Name).IsRequired().HasMaxLength(300);
            builder.Property(n => n.Password).IsRequired();

            builder.HasOne(n => n.Address);
        }
    }
}
