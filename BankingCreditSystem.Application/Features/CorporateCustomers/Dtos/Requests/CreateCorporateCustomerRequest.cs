public class CreateCorporateCustomerRequest
{
    public string CompanyName { get; set; } = null!;
    public string TaxNumber { get; set; } = null!;
    public string TaxOffice { get; set; } = null!;
    public string CompanyRegistrationNumber { get; set; } = null!;
    public string AuthorizedPersonName { get; set; } = null!;
    public DateTime EstablishmentDate { get; set; }
    public string LegalStatus { get; set; } = null!;
    public decimal AnnualRevenue { get; set; }
    public int NumberOfEmployees { get; set; }
    public string SectorOfActivity { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
} 