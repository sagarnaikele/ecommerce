
namespace Ecommerce.Api.Product.Profile
{
  public class ProductProfile : AutoMapper.Profile
  {
    public ProductProfile()
    {
      CreateMap<DB.Product, Models.ProductDto>();
    }

  }
}