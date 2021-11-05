using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Product.Models
{
  /// <summary>
  /// response dto
  /// </summary>
  public class ProductDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
  }
}
