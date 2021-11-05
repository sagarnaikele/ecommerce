using AutoMapper;
using Ecommerce.Api.Order.DB;
using Ecommerce.Api.Order.Interfaces;
using Ecommerce.Api.Order.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Order.Provider
{
  /// <summary>
  /// response dto
  /// </summary>
  public class OrdersProvider : IOrdersProvider
  {

    private readonly OrderDbContext _dbContext;
    private readonly ILogger<OrdersProvider> _logger;
    private readonly IMapper _mapper;
    public OrdersProvider(OrderDbContext context, ILogger<OrdersProvider> logger, IMapper mapper)
    {
      _dbContext = context;
      _logger = logger;
      _mapper = mapper;

      SeedData();
    }

    private void SeedData()
    {
      //if (!_dbContext.Orders.Any())
      //{
      //  var order1= new DB.Order() { Id=100, CustomerId=1};
      //  var order1_Items= new DB.OrderItem() { Id=1000,OrderId=100,ProductId=10,Quantity=10,UnitPrice=123};


      //  _dbContext.Orders.Add(new DB.Order()
      //  {
      //    Id = 1,
      //    CustomerId = 1,
      //    OrderDate = new DateTime(2021, 5, 5),
      //    OrderItems = new List<OrderItem>(){new OrderItem(){
      //      Id=1,
      //      OrderId=1,
      //      ProductId=2,
      //      Quantity=10,
      //      UnitPrice=10 },
      //      new OrderItem(){
      //      Id=8,
      //      OrderId=8,
      //      ProductId=1,
      //      Quantity=10,
      //      UnitPrice=10 } },
      //    Total = 100
      //  });

      //  _dbContext.Orders.Add(new DB.Order()
      //  {
      //    Id = 2,
      //    CustomerId = 2,
      //    OrderDate = new DateTime(2021, 5, 6),
      //    OrderItems = new List<OrderItem>(){new OrderItem(){
      //      Id=2,
      //      OrderId=2,
      //      ProductId=1,
      //      Quantity=10,
      //      UnitPrice=10 } },
      //    Total = 100
      //  });

      //  _dbContext.Orders.Add(new DB.Order()
      //  {
      //    Id = 3,
      //    CustomerId = 3,
      //    OrderDate = new DateTime(2021, 5, 5),
      //    OrderItems = new List<OrderItem>(){new OrderItem(){
      //      Id=3,
      //      OrderId=3,
      //      ProductId=3,
      //      Quantity=10,
      //      UnitPrice=10 } },
      //    Total = 100
      //  });


      //  _dbContext.Orders.Add(new DB.Order()
      //  {
      //    Id = 4,
      //    CustomerId = 4,
      //    OrderDate = new DateTime(2021, 5, 5),
      //    OrderItems = new List<OrderItem>(){new OrderItem(){
      //      Id=4,
      //      OrderId=4,
      //      ProductId=2,
      //      Quantity=10,
      //      UnitPrice=10 } },
      //    Total = 100
      //  });


      //  _dbContext.Orders.Add(new DB.Order()
      //  {
      //    Id = 5,
      //    CustomerId = 5,
      //    OrderDate = new DateTime(2021, 5, 5),
      //    OrderItems = new List<OrderItem>(){new OrderItem(){
      //      Id=5,
      //      OrderId=5,
      //      ProductId=1,
      //      Quantity=10,
      //      UnitPrice=10 } },
      //    Total = 100
      //  });


      //  _dbContext.Orders.Add(new DB.Order()
      //  {
      //    Id = 6,
      //    CustomerId = 1,
      //    OrderDate = new DateTime(2021, 5, 5),
      //    OrderItems = new List<OrderItem>(){new OrderItem(){
      //      Id=6,
      //      OrderId=6,
      //      ProductId=4,
      //      Quantity=10,
      //      UnitPrice=10 } },
      //    Total = 100
      //  });


      //  _dbContext.SaveChanges();
      //}

      if (!_dbContext.Orders.Any())
      {
        var order1 = new DB.Order() { Id = 100, CustomerId = 1, OrderDate = new DateTime(2021, 5, 5), Total = 50 };
        var order1_Items = new DB.OrderItem() { Id = 1000, OrderId = 100, ProductId = 10, Quantity = 10, UnitPrice = 123 };
        var order1_2_Items = new DB.OrderItem() { Id = 1001, OrderId = 100, ProductId = 11, Quantity = 10, UnitPrice = 123 };

        var order2 = new DB.Order() { Id = 101, CustomerId = 2, OrderDate = new DateTime(2021, 5, 5), Total = 50 };
        var order2_1_Items = new DB.OrderItem() { Id = 1002, OrderId = 101, ProductId = 12, Quantity = 10, UnitPrice = 123 };

        var order3 = new DB.Order() { Id = 102, CustomerId = 3, OrderDate = new DateTime(2021, 5, 5), Total = 50 };
        var order3_1_Items = new DB.OrderItem() { Id = 1003, OrderId = 102, ProductId = 13, Quantity = 10, UnitPrice = 123 };


        _dbContext.Orders.AddRange(new DB.Order[] { order1, order2, order3 });
        _dbContext.OrderItems.AddRange(new DB.OrderItem[] { order1_Items, order1_2_Items, order2_1_Items, order3_1_Items });
        _dbContext.SaveChanges();
      }

      if (!_dbContext.OrderItems.Any())
      {
        var order1_Items = new DB.OrderItem() { Id = 1000, OrderId = 100, ProductId = 10, Quantity = 10, UnitPrice = 123 };
        var order1_2_Items = new DB.OrderItem() { Id = 1001, OrderId = 100, ProductId = 11, Quantity = 10, UnitPrice = 123 };
        var order2_1_Items = new DB.OrderItem() { Id = 1002, OrderId = 101, ProductId = 12, Quantity = 10, UnitPrice = 123 };
        var order3_1_Items = new DB.OrderItem() { Id = 1003, OrderId = 102, ProductId = 13, Quantity = 10, UnitPrice = 123 };
        _dbContext.OrderItems.AddRange(new DB.OrderItem[] { order1_Items, order1_2_Items, order2_1_Items, order3_1_Items });
        _dbContext.SaveChanges();
      }

    }

    public async Task<(bool IsSuccess, IEnumerable<OrderDto> Orders, string ErrorMessage)> GetOrdersAsync()
    {
      try
      {
        var orders = await _dbContext.Orders.ToListAsync();
        if (orders != null && orders.Any())
        {
          var results = _mapper.Map<IEnumerable<DB.Order>, IEnumerable<Models.OrderDto>>(orders);
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

    public async Task<(bool IsSuccess, IEnumerable<OrderDto> Orders, string ErrorMessage)> GetOrderAsync(int customerId)
    {
      try
      {
        var orders = await _dbContext.Orders.Include(e=>e.OrderItems).Where(e => e.CustomerId == customerId).ToListAsync();
        if (orders != null)
        {
          var results = _mapper.Map<IEnumerable<DB.Order>, IEnumerable<Models.OrderDto>>(orders);
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
