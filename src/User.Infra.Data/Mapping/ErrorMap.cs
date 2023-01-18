using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entities;

namespace User.Infra.Data.Mapping
{
    public class ErrorMap : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("ERRORS");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.Property(p => p.Date)
                .IsRequired()
                .HasColumnName("DATE")
                .HasColumnType("datetime");

            builder.Property(p => p.Message)
                .IsRequired()
                .HasColumnName("MESSAGE")
                .HasColumnType("varchar(300)");
        }
    }
}
