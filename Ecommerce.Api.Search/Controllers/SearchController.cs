using Ecommerce.Api.Search.Interfaces;
using Ecommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Controllers
{
  [ApiController]
  [Route("api/search")]
  public class SearchController : ControllerBase
  {
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
      _searchService= searchService;

    }

    [HttpPost]
    public async Task<IActionResult> SearchAsync(SearchTerm term)
    {
      var res = await _searchService.SearchAsync(term.CustomerId);
      if (res.IsSuccess)
      {
        return Ok(res.SearchResults);

      }
      return NotFound();
    }
  }
}
