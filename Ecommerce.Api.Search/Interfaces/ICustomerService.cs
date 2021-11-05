﻿using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Interfaces
{
  /// <summary>
  /// response dto
  /// </summary>
  public interface ICustomersService
  {
    Task<(bool IsSuccess, dynamic Customer, string ErrorMessage)> GetCustomersAsync(int customerId);
  }
}
