public class GetListCorporateCustomerResponse 
{
    public IList<GetCorporateCustomerListItemDto> Items { get; set; } = null!;
}

public class GetCorporateCustomerListItemDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string TaxNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int CreditScore { get; set; }
} 