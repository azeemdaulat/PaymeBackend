using Microsoft.EntityFrameworkCore;
using Payme.EntityConfiguration;
using Payme.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Payme.Context;

public class ApplicationDbContext : DbContext
{
    // Constructor for Dependency Injection
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets for tables
    public DbSet<PaymentLink> PaymentLinks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure PaymentLink entity using a separate class
        modelBuilder.ApplyConfiguration(new PaymentLinkEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryEntityConfiguration());
    }
}
