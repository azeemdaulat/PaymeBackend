using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Payme.Model;

namespace Payme.EntityConfiguration;

public class PaymentLinkEntityConfiguration : IEntityTypeConfiguration<PaymentLink>
{
    public void Configure(EntityTypeBuilder<PaymentLink> entity)
    {
        entity.HasKey(e => e.Id); // Primary Key

        entity.Property(e => e.OrderId)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.BuyerName)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(e => e.Amount)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

        entity.Property(e => e.Currency)
              .HasMaxLength(10)
              .IsRequired();

        entity.Property(e => e.ExpiryDate)
              .IsRequired();

        entity.Property(e => e.Status)
              .HasMaxLength(20)
              .IsRequired();

        entity.Property(e => e.CreatedAt)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();

        entity.Property(e => e.UpdatedAt);
    }
}
