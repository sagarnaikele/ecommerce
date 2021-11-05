using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customer.Models
{
  /// <summary>
  /// response dto
  /// </summary>
  public class CustomerDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
  }
}
