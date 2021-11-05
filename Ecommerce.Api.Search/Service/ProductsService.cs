﻿using Ecommerce.Api.Search.Interfaces;
using Ecommerce.Api.Search.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Provider
{
  /// <summary>
  /// response dto
  /// </summary>
  public class ProductsService : IProductsService
  {

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger _logger;
    public ProductsService(IHttpClientFactory httpClientFactory,ILogger<ProductsService> logger)
    {
      _httpClientFactory= httpClientFactory;
      _logger= logger;
    }
    public async Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync()
    {
      try
      {
        var client =_httpClientFactory.CreateClient("ProductsService");
        var response=await client.GetAsync($"api/products");
        if (response.IsSuccessStatusCode)
        {
          var content=await response.Content.ReadAsByteArrayAsync();
          var options=new JsonSerializerOptions() { PropertyNameCaseInsensitive=true};
          var result=JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);
          return (true,result,null);
        }
        return (false, null, response.ReasonPhrase);
      }
      catch (Exception ex)
      {
        _logger?.LogError(ex.ToString());
        return (false, null, ex.Message);
      }
    }
  }
}
