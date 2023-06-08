using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Versta.OrderApi.DbContexts;
using Versta.OrderApi.Models;
using Versta.OrderApi.Models.Dtos;


namespace Versta.OrderApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly VerstaDbContext _db;

        public OrderRepository(VerstaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

		public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
		{
			var order = _mapper.Map<OrderDto, Order>(orderDto);

            _db.Addresses.Add(order.SenderAddress);
            _db.Addresses.Add(order.RecipientAddress);

            await _db.SaveChangesAsync();

            _db.Orders.Add(order);

            await _db.SaveChangesAsync();
            return _mapper.Map<Order, OrderDto>(order);
		}

		public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _db.GetOrdersSummary().FirstAsync(x => x.Id == orderId);
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            var orders = await _db.GetOrdersSummary()
                .OrderByDescending(x => x.Id).ToListAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
