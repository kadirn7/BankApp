using System;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalId { get; set; } = default!; // TC Kimlik No
    public DateTime DateOfBirth { get; set; }
    public string Occupation { get; set; } = default!;
    public decimal MonthlyIncome { get; set; }
} 