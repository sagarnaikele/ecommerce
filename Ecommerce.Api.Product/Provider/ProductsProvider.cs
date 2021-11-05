using AutoMapper;
using Ecommerce.Api.Product.DB;
using Ecommerce.Api.Product.Interfaces;
using Ecommerce.Api.Product.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Product.Provider
{
  /// <summary>
  /// response dto
  /// </summary>
  public class ProductsProvider : IProductsProvider
  {

    private readonly ProductDbContext _dbContext;
    private readonly ILogger<ProductsProvider> _logger;
    private readonly IMapper _mapper;
    public ProductsProvider(ProductDbContext context, ILogger<ProductsProvider> logger, IMapper mapper)
    {
      _dbContext = context;
      _logger = logger;
      _mapper = mapper;

      SeedData();
    }

    private void SeedData()
    {
      if (!_dbContext.Products.Any())
      {
        _dbContext.Products.Add(new DB.Product() { Id = 10, Name = "Computer", Price = 100, Inventory = 100 });
        _dbContext.Products.Add(new DB.Product() { Id = 11, Name = "Mouse", Price = 10, Inventory = 150 });
        _dbContext.Products.Add(new DB.Product() { Id = 12, Name = "Monito", Price = 50, Inventory = 10 });
        _dbContext.Products.Add(new DB.Product() { Id = 13, Name = "Keyboard", Price = 10, Inventory = 150 });
        _dbContext.Products.Add(new DB.Product() { Id = 14, Name = "CPU", Price = 100, Inventory = 20 });
        _dbContext.Products.Add(new DB.Product() { Id = 15, Name = "Router", Price = 10, Inventory = 100 });
        _dbContext.SaveChanges();
      }
    }

    public async Task<(bool IsSuccess, IEnumerable<ProductDto> Products, string ErrorMessage)> GetProductsAsync()
    {
      try
      {
       var products= await _dbContext.Products.ToListAsync();
        if (products!=null && products.Any())
        {
         var results= _mapper.Map<IEnumerable<DB.Product>,IEnumerable<Models.ProductDto>>(products);
          return (true, results, null);
        }
        return (false, null, "Not Found");
      }
      catch (Exception ex)
      {
        _logger?.LogError(ex.ToString());
        return (false, null, ex.Message);
      }
    }

    public async Task<(bool IsSuccess, ProductDto Product, string ErrorMessage)> GetProductAsync(int id)
    {
      try
      {
        var product = await _dbContext.Products.FirstOrDefaultAsync(e=>e.Id==id);
        if (product != null)
        {
          var results = _mapper.Map<DB.Product, Models.ProductDto>(product);
          return (true, results, null);
        }
        return (false, null, "Not Found");
      }
      catch (Exception ex)
      {
        _logger?.LogError(ex.ToString());
        return (false, null, ex.Message);
      }
    }
  }
}
