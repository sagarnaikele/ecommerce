using System;
using System.Collections.Generic;

namespace Ecommerce.Api.Search.Models
{
  /// <summary>
  /// response dto
  /// </summary>
  public class Order
  {
    public int Id { get; set; }
    //public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public List<OrderItem> OrderItems { get; set; }
  }
}
