namespace C_Sharp_.Net_Address_Book.Intefaces;

public interface ICustomerService
{
    IServiceResult AddCustomerToList(ICustomer customer);
    IServiceResult GetCustomersFromList();

    IServiceResult DeleteCustomer(string email);
}

