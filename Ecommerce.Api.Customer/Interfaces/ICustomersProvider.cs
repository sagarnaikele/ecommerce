using Ecommerce.Api.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customer.Interfaces
{
  /// <summary>
  /// response dto
  /// </summary>
  public interface ICustomersProvider
  {
    Task<(bool IsSuccess, IEnumerable<CustomerDto> Customers, string ErrorMessage)> GetCustomersAsync();
    Task<(bool IsSuccess, CustomerDto Customer, string ErrorMessage)> GetCustomerAsync(int id);
  }
}
