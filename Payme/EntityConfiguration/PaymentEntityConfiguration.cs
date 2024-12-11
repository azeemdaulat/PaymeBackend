using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Payme.Model;

namespace Payme.EntityConfiguration;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        entity.HasKey(e => e.PaymentId); // Primary Key

        entity.Property(e => e.Amount)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

        entity.Property(e => e.PaymentMethod)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.TransactionId)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(e => e.Status)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.CreatedAt)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();

        entity.HasOne(e => e.Order)
              .WithMany()
              .HasForeignKey(e => e.OrderId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
