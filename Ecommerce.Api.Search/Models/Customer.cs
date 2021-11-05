using System;
using System.Collections.Generic;

namespace Ecommerce.Api.Search.Models
{
  /// <summary>
  /// response dto
  /// </summary>
  public class Customer
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
  }
}
