using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class BankingCreditSystemDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

    public BankingCreditSystemDbContext(DbContextOptions<BankingCreditSystemDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TPT Configuration
        modelBuilder.Entity<Customer>()
            .UseTptMappingStrategy();

        modelBuilder.Entity<Customer>()
            .ToTable("Customers");

        modelBuilder.Entity<IndividualCustomer>()
            .ToTable("IndividualCustomers");

        modelBuilder.Entity<CorporateCustomer>()
            .ToTable("CorporateCustomers");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
} 