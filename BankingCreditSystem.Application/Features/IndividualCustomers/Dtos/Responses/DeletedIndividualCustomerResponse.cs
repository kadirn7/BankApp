public class DeletedIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
    public string Message { get; set; } = null!;
} 
