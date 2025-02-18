

namespace BankingCreditSystem.Persistence.Repositories
{
    public class CorporateCustomerRepository : CustomerRepository<CorporateCustomer>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(BankingCreditSystemDbContext context) : base(context)
        {
        }
    }
} 