public class UpdatedCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime UpdatedDate { get; set; }
} 