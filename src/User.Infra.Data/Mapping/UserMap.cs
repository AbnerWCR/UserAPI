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

            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.OwnsOne(x => x.Name)
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("FIRST_NAME")
                .HasColumnType("varchar(50)");

            builder.OwnsOne(x => x.Name)
                .Property(x => x.LastName)
                .HasColumnName("LAST_NAME")
                .HasColumnType("varchar(50)");

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(180)");

            builder.OwnsOne(x => x.Password)
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("PASSWORD")
                .HasColumnType("varchar(200)");

            builder.OwnsOne(x => 
                                x.Password,
                                sa => sa.Ignore(p => p.PasswordText));

            builder.OwnsOne(x => x.Role)
                .Property(x => x.UserRole)
                .IsRequired()
                .HasColumnName("ROLE")
                .HasColumnType("varchar(6)");
        }
    }
}
