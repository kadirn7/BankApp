public class GetListIndividualCustomerRequest : BasePageableRequest
{
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool IsAscending { get; set; } = true;
}

public class BasePageableRequest
{
    public int Index { get; set; } = 0;
    public int Size { get; set; } = 10;
} 