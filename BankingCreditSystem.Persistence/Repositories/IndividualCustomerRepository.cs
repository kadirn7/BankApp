

namespace BankingCreditSystem.Persistence.Repositories
{
    public class IndividualCustomerRepository : CustomerRepository<IndividualCustomer>, IIndividualCustomerRepository
    {
        public IndividualCustomerRepository(BankingCreditSystemDbContext context) : base(context)
        {
        }
    }
} 