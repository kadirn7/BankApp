public interface ICustomerRepository<T> : IAsyncRepository<T, Guid>
    where T : Entity<Guid>
{
    // Customer'a özel metodlar buraya eklenebilir
} 