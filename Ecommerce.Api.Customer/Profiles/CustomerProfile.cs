
namespace Ecommerce.Api.Customer.Profile
{
  public class CustomerProfile : AutoMapper.Profile
  {
    public CustomerProfile()
    {
      CreateMap<DB.Customer, Models.CustomerDto>();
    }

  }
}