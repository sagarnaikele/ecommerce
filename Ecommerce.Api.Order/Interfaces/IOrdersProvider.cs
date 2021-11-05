using Ecommerce.Api.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Order.Interfaces
{
  /// <summary>
  /// response dto
  /// </summary>
  public interface IOrdersProvider
  {
    Task<(bool IsSuccess, IEnumerable<OrderDto> Orders, string ErrorMessage)> GetOrdersAsync();
    Task<(bool IsSuccess, IEnumerable<OrderDto> Orders, string ErrorMessage)> GetOrderAsync(int customerId);
  }
}
