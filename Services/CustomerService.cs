using C_Sharp_.Net_Address_Book.Intefaces;
using C_Sharp_.Net_Address_Book.Models;
using C_Sharp_.Net_Address_Book.Models.Responses;
using Newtonsoft.Json;
using System.Diagnostics;

namespace C_Sharp_.Net_Address_Book.Services;

public class CustomerService : ICustomerService
{
    private FileService _fileService = new FileService(@"U:\.NET\C#(C-sharp)\Projects\content.json");
    private static readonly List<ICustomer> _customers = [];


    /// <summary>
    /// Add customer to list
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    public IServiceResult AddCustomerToList(ICustomer customer)
    {
        IServiceResult response = new ServiceResult();

        try
        {
            if (!_customers.Any(x => x.Email == customer.Email))
            {
                _customers.Add(customer);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customers));
                response.Status = Enums.ServiceStatus.SUCCESSED;
            }
            else
            {
                response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Get Customer from list
    /// </summary>
    /// <returns></returns>
    public IServiceResult GetCustomersFromList()
    {
        IServiceResult response = new ServiceResult();

         try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content))
                {
                    _customers.Clear(); // Clear the existing list before deserialization
                    _customers.AddRange(JsonConvert.DeserializeObject<List<Customer>>(content)!);
                    response.Result = _customers;
                }
                response.Status = Enums.ServiceStatus.SUCCESSED;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.Status = Enums.ServiceStatus.FAILED;
                response.Result = null;
            }

        return response;
    }

    /// <summary>
    /// Delete customer if it is the same email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public IServiceResult DeleteCustomer(string email)
    {
        IServiceResult response = new ServiceResult();

        try
        {
            var customerToDelete = _customers.FirstOrDefault(x => x.Email == email);

            if (customerToDelete != null)
            {
                _customers.Remove(customerToDelete);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customers));
                response.Status = Enums.ServiceStatus.SUCCESSED;
            }
            else
            {
                response.Status = Enums.ServiceStatus.FAILED;
                response.Result = "Customer not found.";
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }
}

