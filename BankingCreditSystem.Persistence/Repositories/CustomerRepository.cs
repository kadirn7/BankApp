
    
public class CustomerRepository<T> : EfRepositoryBase<T, Guid, BankingCreditSystemDbContext>, ICustomerRepository<T>
where T : Customer
{   
    public CustomerRepository(BankingCreditSystemDbContext context) : base(context)
    {
    }
} 