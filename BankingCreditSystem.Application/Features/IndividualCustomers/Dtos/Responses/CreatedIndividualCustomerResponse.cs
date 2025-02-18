public class CreatedIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string Message { get; set; } = null!;
} 