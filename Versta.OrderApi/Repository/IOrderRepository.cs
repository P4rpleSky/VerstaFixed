using Versta.OrderApi.Models.Dtos;

namespace Versta.OrderApi.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
    }
}
