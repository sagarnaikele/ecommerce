using Ecommerce.Api.Order.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Order.Controllers
{
  [ApiController]
  [Route("api/orders")]
  public class OrdersController : ControllerBase
  {
    private readonly IOrdersProvider provider;

    public OrdersController(IOrdersProvider productsProvider)
    {
      provider= productsProvider;

    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
      var res = await provider.GetOrdersAsync();
      if (res.IsSuccess)
      {
        return Ok(res.Orders);

      }
      return NotFound();
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetOrdersAsync(int customerId)
    {
      var res = await provider.GetOrderAsync(customerId);
      if (res.IsSuccess)
      {
        return Ok(res.Orders);

      }
      return NotFound();
    }
  }
}
