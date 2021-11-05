using Ecommerce.Api.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Product.Interfaces
{
  /// <summary>
  /// response dto
  /// </summary>
  public interface IProductsProvider
  {
    Task<(bool IsSuccess, IEnumerable<ProductDto> Products, string ErrorMessage)> GetProductsAsync();
    Task<(bool IsSuccess, ProductDto Product, string ErrorMessage)> GetProductAsync(int id);
  }
}
