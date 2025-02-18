public class GetListIndividualCustomerResponse 
{
    public IList<GetIndividualCustomerListItemDto> Items { get; set; } = null!;
}

public class GetIndividualCustomerListItemDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int CreditScore { get; set; }
} 