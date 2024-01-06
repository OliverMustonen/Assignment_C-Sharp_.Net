﻿namespace C_Sharp_.Net_Address_Book.Intefaces;

public interface ICustomer
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string? PhoneNumber { get; set; }
    string Address { get; set; }
}
