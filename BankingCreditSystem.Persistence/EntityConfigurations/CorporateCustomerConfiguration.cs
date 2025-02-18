using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations
{
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("CorporateCustomers");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.CompanyName)
                .HasMaxLength(250)
                .IsRequired();
                
            builder.Property(c => c.TaxNumber)
                .HasMaxLength(10)
                .IsRequired();
                
            builder.Property(c => c.CompanyRegistrationNumber)
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(c => c.EstablishmentDate)
                .IsRequired();
                
            builder.Property(c => c.LegalStatus)
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(c => c.AnnualRevenue)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
                
            builder.Property(c => c.NumberOfEmployees)
                .IsRequired();
                
            builder.Property(c => c.SectorOfActivity)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(c => c.TaxNumber)
                .IsUnique();
            builder.UseTptMappingStrategy();
        }
    }
} 