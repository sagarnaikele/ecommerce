using AutoMapper;
using Ecommerce.Api.Customer.DB;
using Ecommerce.Api.Customer.Interfaces;
using Ecommerce.Api.Customer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customer.Provider
{
  /// <summary>
  /// response dto
  /// </summary>
  public class CustomersProvider : ICustomersProvider
  {

    private readonly CustomerDbContext _dbContext;
    private readonly ILogger<CustomersProvider> _logger;
    private readonly IMapper _mapper;
    public CustomersProvider(CustomerDbContext context, ILogger<CustomersProvider> logger, IMapper mapper)
    {
      _dbContext = context;
      _logger = logger;
      _mapper = mapper;

      SeedData();
    }

    private void SeedData()
    {
      if (!_dbContext.Customers.Any())
      {
        _dbContext.Customers.Add(new DB.Customer() { Id = 1, Name = "Computer",Address="India" });
        _dbContext.Customers.Add(new DB.Customer() { Id = 2, Name = "Mouse", Address = "US" });
        _dbContext.Customers.Add(new DB.Customer() { Id = 3, Name = "Monito", Address = "Noida" });
        _dbContext.Customers.Add(new DB.Customer() { Id = 4, Name = "Keyboard", Address = "India" });
        _dbContext.Customers.Add(new DB.Customer() { Id = 5, Name = "CPU",  Address = "UK" });
        _dbContext.Customers.Add(new DB.Customer() { Id = 6, Name = "Router", Address = "Maharashtra" });
        _dbContext.SaveChanges();
      }
    }

    public async Task<(bool IsSuccess, IEnumerable<CustomerDto> Customers, string ErrorMessage)> GetCustomersAsync()
    {
      try
      {
       var products= await _dbContext.Customers.ToListAsync();
        if (products!=null && products.Any())
        {
         var results= _mapper.Map<IEnumerable<DB.Customer>,IEnumerable<Models.CustomerDto>>(products);
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

    public async Task<(bool IsSuccess, CustomerDto Customer, string ErrorMessage)> GetCustomerAsync(int id)
    {
      try
      {
        var product = await _dbContext.Customers.FirstOrDefaultAsync(e=>e.Id==id);
        if (product != null)
        {
          var results = _mapper.Map<DB.Customer, Models.CustomerDto>(product);
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
