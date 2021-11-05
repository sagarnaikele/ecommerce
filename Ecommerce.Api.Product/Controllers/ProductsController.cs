using Ecommerce.Api.Product.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Product.Controllers
{
  [ApiController]
  [Route("api/products")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductsProvider provider;

    public ProductsController(IProductsProvider productsProvider)
    {
      provider= productsProvider;

    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
      var res = await provider.GetProductsAsync();
      if (res.IsSuccess)
      {
        return Ok(res.Products);

      }
      return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductsAsync(int id)
    {
      var res = await provider.GetProductAsync(id);
      if (res.IsSuccess)
      {
        return Ok(res.Product);

      }
      return NotFound();
    }
  }
}
