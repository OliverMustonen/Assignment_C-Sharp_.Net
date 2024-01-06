using C_Sharp_.Net_Address_Book.Enums;
using C_Sharp_.Net_Address_Book.Intefaces;
using C_Sharp_.Net_Address_Book.Models;
using System;

namespace C_Sharp_.Net_Address_Book.Services;
/// <summary>
/// Main menu
/// </summary>
public interface IMenuService
{
    void ShowMainMenu();
}
/// <summary>
/// Main menu detailed options
/// </summary>
public class MenuService : IMenuService
{
    private readonly ICustomerService _customerService = new CustomerService();
    public void ShowMainMenu()
    {
        while (true)
        {
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine($"{"1.",-4} Add New Customer");
            Console.WriteLine($"{"2.",-4} View Customer List");
            Console.WriteLine($"{"0.",-4} Exit Application");
            Console.WriteLine();
            Console.Write("Enter Menu Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowAddCustomerOption();
                    break;

                case "2":
                    ShowViewCustomerListOption();
                    break;

                case "0":
                    ShowExitApplicationOption();
                    break;

                default:
                    Console.WriteLine("\nInvalid Option selected. Please any key to try again.");
                    Console.ReadKey();
                    break;
            }


        }
    }
    /// <summary>
    /// Exit option
    /// </summary>
    private void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to close this application? (y/n): ");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Environment.Exit(0);
        }
    }
    /// <summary>
    /// Adding customer
    /// </summary>
    private void ShowAddCustomerOption()
    {
        ICustomer customer = new Customer();

        DisplayMenuTitle("Add New Customer");

        Console.Write("First Name: ");
        customer.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        customer.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        customer.Email = Console.ReadLine()!;

        Console.Write("Address: ");
        customer.Address = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        customer.PhoneNumber = Console.ReadLine()!;

        

        var res = _customerService.AddCustomerToList(customer);

        switch (res.Status)
        {
            case Enums.ServiceStatus.SUCCESSED:
                Console.WriteLine("The customer was added successfully.");
                break;

            case Enums.ServiceStatus.ALREADY_EXISTS:
                Console.WriteLine("The customer already exists.");
                break;

            case Enums.ServiceStatus.FAILED:
                Console.WriteLine("Failed when trying to add the customer to customer list.");
                Console.WriteLine("See error message :: " + res.Result.ToString());
                break;
        }

        DisplayPressAnyKey();
    }

    /// <summary>
    /// View list, search for specific customer to view more infomation with delete option
    /// </summary>
    private void ShowViewCustomerListOption()
    {
        DisplayMenuTitle("Customer List");
        var res = _customerService.GetCustomersFromList();

        if (res.Status == ServiceStatus.SUCCESSED)
        {
            if (res.Result is List<ICustomer> customerList)
            {
                if (!customerList.Any())
                {
                    Console.WriteLine("No customers found.");
                }
                else
                {
                    foreach (var customer in customerList)
                    {
                        Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}>\n");
                    }

                    Console.Write("Do you want more detailed information write their email? (y/n): ");
                    var searchOption = Console.ReadLine()?.ToLower();

                    if (searchOption == "y")
                    {
                        Console.Clear();
                        Console.Write("Enter Email to search: ");
                        string searchEmail = Console.ReadLine()!;

                        var searchedCustomer = customerList.FirstOrDefault(c => c.Email.Equals(searchEmail, StringComparison.OrdinalIgnoreCase));

                        if (searchedCustomer != null)
                        {
                            Console.WriteLine($"Customer Details for: {searchedCustomer.FirstName} {searchedCustomer.LastName}:");
                            Console.WriteLine($"Email: {searchedCustomer.Email}");
                            Console.WriteLine($"Phone Number: {searchedCustomer.PhoneNumber}");
                            Console.WriteLine($"Address: {searchedCustomer.Address}\n");

                            Console.Write("Do you want to delete this customer? (y/n): ");
                            var deleteOption = Console.ReadLine()?.ToLower();

                            if (deleteOption == "y")
                            {
                                var deleteResult = _customerService.DeleteCustomer(searchedCustomer.Email);

                                switch (deleteResult.Status)
                                {
                                    case ServiceStatus.SUCCESSED:
                                        Console.WriteLine("Customer deleted successfully.");
                                        break;

                                    case ServiceStatus.FAILED:
                                        Console.WriteLine($"Failed to delete customer. {deleteResult.Result}");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No customer found with the email: {searchEmail}.");
                        }
                    }
                }
            }
        }

        DisplayPressAnyKey();
    }



    /// <summary>
    /// Menu Title will change title depending on menu
    /// </summary>
    /// <param name="title"></param>
    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"## {title} ##");
        Console.WriteLine();
    }

    /// <summary>
    /// Press any key to continue
    /// </summary>
    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

}
