using Ecommerce.Api.Order.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Order.Models
{
  /// <summary>
  /// order response dto
  /// </summary>
  public class OrderDto
  {
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public List<OrderItem> OrderItems { get; set; }
  }
}
