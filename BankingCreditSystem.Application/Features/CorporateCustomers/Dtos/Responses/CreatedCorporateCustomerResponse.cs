public class CreatedCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string TaxNumber { get; set; } = null!;
    public string CompanyRegistrationNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
} 