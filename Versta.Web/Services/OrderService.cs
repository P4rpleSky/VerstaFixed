using Versta.Web.Models;
using Versta.Web.Services.Interfaces;

namespace Versta.Web.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _clientFactory;

        public OrderService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

		public async Task<ResponseDto> CreateOrderAsync(OrderDto orderDto)
		{
			return await this.SendAsync(new ApiRequest
			{
				ApiType = SD.ApiType.POST,
                Data = orderDto,
				Url = SD.BaseUrl + $"api/orders/"
			});
		}

		public async Task<ResponseDto> GetOrderByIdAsync(int orderId)
        {
            return await this.SendAsync(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BaseUrl + $"api/orders/orderId={orderId}"
            });
        }

        public async Task<ResponseDto> GetOrdersAsync()
        {
            return await this.SendAsync(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BaseUrl + "api/orders/"
            });
        }
    }
}
