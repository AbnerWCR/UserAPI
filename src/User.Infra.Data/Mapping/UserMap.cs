using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = User.Domain.Entities;

namespace User.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<Entity.User>
    {
        public void Configure(EntityTypeBuilder<Entity.User> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasConversion(p => p.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("NAME")
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Email)
                .HasConversion(p => p.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(180)");

            builder.Property(p => p.Password)
                .HasConversion(p => p.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("PASSWORD")
                .HasColumnType("varchar(18)");
        }
    }
}
