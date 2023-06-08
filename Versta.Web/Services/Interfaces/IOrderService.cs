using Versta.Web.Models;

namespace Versta.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseDto> GetOrdersAsync();
        Task<ResponseDto> GetOrderByIdAsync(int orderId);
        Task<ResponseDto> CreateOrderAsync(OrderDto orderDto);
    }
}
