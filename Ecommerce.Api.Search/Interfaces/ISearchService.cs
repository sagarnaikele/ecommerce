using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Interfaces
{
  /// <summary>
  /// response dto
  /// </summary>
  public interface ISearchService
  {
    Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int id);
  }
}
