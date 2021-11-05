using Ecommerce.Api.Search.Interfaces;
using Ecommerce.Api.Search.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Provider
{
  /// <summary>
  /// response dto
  /// </summary>
  public class SearchService : ISearchService
  {
    private readonly IOrderService _orderService;
    private readonly IProductsService _productService;
    private readonly ICustomersService _customersService;
    public SearchService(IOrderService orderService, IProductsService productService, ICustomersService customersService)
    {
      _orderService= orderService;
      _productService = productService;
      _customersService= customersService;
    }

    public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
    {
     var orderResult= await _orderService.GetOrdersAsync(customerId: customerId);
      var products= await _productService.GetProductsAsync();
      var customer= await _customersService.GetCustomersAsync(customerId);

      if (orderResult.IsSuccess)
      {
        foreach (var order in orderResult.Orders)
        {
          foreach (var item in order.OrderItems)
          {
            item.ProductName=products.IsSuccess?
              products.Products.FirstOrDefault(p=>p.Id==item.ProductId)?.Name:
              "Product is not defined.";

          }
        }
        var result = new { 
          Customer= customer.IsSuccess? customer.Customer:new {Name="Customer did not found" },
          Orders = orderResult.Orders };
      return (true, result);
      }
      return (false,null);
    }
  }
}
