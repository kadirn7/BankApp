public class UpdateCorporateCustomerRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string LegalStatus { get; set; } = null!;
    public decimal AnnualRevenue { get; set; }
    public int NumberOfEmployees { get; set; }
    public string SectorOfActivity { get; set; } = null!;
} 