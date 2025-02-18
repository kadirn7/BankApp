using System;

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string CompanyRegistrationNumber { get; set; } = default!;
    public DateTime EstablishmentDate { get; set; }
    public string LegalStatus { get; set; } = default!; // AŞ, LTD vs.
    public decimal AnnualRevenue { get; set; }
    public int NumberOfEmployees { get; set; }
    public string SectorOfActivity { get; set; } = default!;
} 