using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Payme.Model;

namespace Payme.EntityConfiguration;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(e => e.OrderId); // Primary Key

        entity.Property(e => e.OrderNumber)
              .IsRequired()
              .HasMaxLength(50);

        entity.HasIndex(e => e.OrderNumber)
              .IsUnique();

        entity.Property(e => e.TotalAmount)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

        entity.Property(e => e.Status)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.CreatedAt)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();

        entity.Property(e => e.UpdatedAt);

        entity.HasOne(e => e.User)
              .WithMany()
              .HasForeignKey(e => e.UserId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
