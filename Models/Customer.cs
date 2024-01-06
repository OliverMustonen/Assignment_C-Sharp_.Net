using C_Sharp_.Net_Address_Book.Intefaces;

namespace C_Sharp_.Net_Address_Book.Models;

public class Customer : ICustomer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Address { get; set; } = null!;

}
