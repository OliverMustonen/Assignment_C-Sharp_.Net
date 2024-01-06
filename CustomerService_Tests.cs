using System;
using System.Collections.Generic;
using System.Linq;
using C_Sharp_.Net_Address_Book.Intefaces;
using C_Sharp_.Net_Address_Book.Models;
using C_Sharp_.Net_Address_Book.Models.Responses;
using C_Sharp_.Net_Address_Book.Services;
using Newtonsoft.Json;
using Xunit;

namespace C_Sharp_.Net_Address_Book.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void AddCustomerToList_Success()
        {
            // Arrange
            ICustomerService customerService = new CustomerService();
            ICustomer customer = new Customer { Email = "oliver@example.com" };

            // Act
            IServiceResult result = customerService.AddCustomerToList(customer);

            // Assert
            Assert.Equal(Enums.ServiceStatus.SUCCESSED, result.Status);
            // Additional assertions if needed
        }

        [Fact]
        public void AddCustomerToList_AlreadyExists()
        {
            // Arrange
            ICustomerService customerService = new CustomerService();
            ICustomer existingCustomer = new Customer { Email = "test@example.com" };
            customerService.AddCustomerToList(existingCustomer); // Add the customer first

            ICustomer customer = new Customer { Email = "test@example.com" }; // Same email again

            // Act
            IServiceResult result = customerService.AddCustomerToList(customer);

            // Assert
            Assert.Equal(Enums.ServiceStatus.ALREADY_EXISTS, result.Status);
            // Additional assertions if needed
        }

        [Fact]
        public void GetCustomersFromList_Success()
        {
            // Arrange
            ICustomerService customerService = new CustomerService();

            // Act
            IServiceResult result = customerService.GetCustomersFromList();

            // Assert
            Assert.Equal(Enums.ServiceStatus.SUCCESSED, result.Status);
            Assert.NotNull(result.Result);
            // Additional assertions if needed
        }

        [Fact]
        public void DeleteCustomer_Success()
        {
            // Arrange
            ICustomerService customerService = new CustomerService();
            ICustomer customer = new Customer { Email = "oliver@example.com" };
            customerService.AddCustomerToList(customer); // Add the customer first

            // Act
            IServiceResult result = customerService.DeleteCustomer("oliver@example.com");

            // Assert
            Assert.Equal(Enums.ServiceStatus.SUCCESSED, result.Status);
            // Additional assertions if needed
        }

      
    }
}
