public class GetIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Occupation { get; set; } = null!;
    public decimal MonthlyIncome { get; set; }
    public int CreditScore { get; set; }
    public string Message { get; set; } = null!;
} 
