
namespace Ecommerce.Api.Order.Profile
{
  public class OrderProfile : AutoMapper.Profile
  {
    public OrderProfile()
    {
      CreateMap<DB.Order, Models.OrderDto>();
      CreateMap<DB.OrderItem, Models.OrderItemDto>();
    }

  }
}