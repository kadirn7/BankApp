public class GetListCorporateCustomerRequest : BasePageableRequest
{
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool IsAscending { get; set; } = true;
} 