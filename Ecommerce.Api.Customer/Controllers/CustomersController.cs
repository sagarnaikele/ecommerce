using Ecommerce.Api.Customer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customer.Controllers
{
  [ApiController]
  [Route("api/customers")]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomersProvider provider;

    public CustomersController(ICustomersProvider customersProvider)
    {
      provider= customersProvider;

    }

    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync()
    {
      var res = await provider.GetCustomersAsync();
      if (res.IsSuccess)
      {
        return Ok(res.Customers);

      }
      return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomersAsync(int id)
    {
      var res = await provider.GetCustomerAsync(id);
      if (res.IsSuccess)
      {
        return Ok(res.Customer);

      }
      return NotFound();
    }
  }
}
