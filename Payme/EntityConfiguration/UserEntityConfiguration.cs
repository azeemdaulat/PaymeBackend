using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Payme.Model;

namespace Payme.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(e => e.UserId); // Primary Key

        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(255);

        entity.Property(e => e.Email)
              .IsRequired()
              .HasMaxLength(255);

        entity.HasIndex(e => e.Email)
              .IsUnique();

        entity.Property(e => e.PasswordHash)
              .IsRequired()
              .HasMaxLength(255);

        entity.Property(e => e.Role)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.PhoneNumber)
              .HasMaxLength(20);

        entity.Property(e => e.CreatedAt)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();
    }
}
