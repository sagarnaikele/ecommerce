using System;
using System.Collections.Generic;

namespace Ecommerce.Api.Search.Models
{
  /// <summary>
  /// response dto
  /// </summary>
  public class Product
  {
    public int Id { get; set; }
    //public int CustomerId { get; set; }
    public string Name { get; set; }
  }
}
