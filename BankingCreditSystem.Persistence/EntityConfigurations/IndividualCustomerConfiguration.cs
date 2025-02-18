using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations
{
    public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            builder.ToTable("IndividualCustomers");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.FirstName)
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(c => c.LastName)
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(c => c.NationalId)
                .HasMaxLength(11)
                .IsRequired();
                
            builder.Property(c => c.DateOfBirth)
                .IsRequired();
                
            builder.Property(c => c.Occupation)
                .HasMaxLength(100)
                .IsRequired();
                
            builder.Property(c => c.MonthlyIncome)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasIndex(c => c.NationalId)
                .IsUnique();
            builder.UseTptMappingStrategy();
        }
    }
} 