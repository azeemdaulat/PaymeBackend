using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Payme.Model;

namespace Payme.EntityConfiguration;

public class DeliveryEntityConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> entity)
    {
        entity.HasKey(e => e.DeliveryId); // Primary Key

        entity.Property(e => e.Status)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.AssignedAt)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();

        entity.Property(e => e.DeliveredAt);

        entity.HasOne(e => e.Order)
              .WithMany()
              .HasForeignKey(e => e.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.Rider)
              .WithMany()
              .HasForeignKey(e => e.RiderId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
