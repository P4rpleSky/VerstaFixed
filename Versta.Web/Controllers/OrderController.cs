using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Versta.Web.Models;
using Versta.Web.Services.Interfaces;


namespace Versta.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrdersListIndex()
        {
			var orderDtosList = new List<OrderDto>();
			var response = await _orderService.GetOrdersAsync();
			if (response is not null && response.IsSuccess)
			{
				orderDtosList = JsonConvert.DeserializeObject<List<OrderDto>>(response.Result.ToString());
			}
			return View(orderDtosList);
		}

		public async Task<IActionResult> OrderIndex(SD.ViewType viewType, int orderId = 0)
		{
			if (viewType == SD.ViewType.Info)
			{
				var response = await _orderService.GetOrderByIdAsync(orderId);
				if (response.IsSuccess)
				{
					var orderDto = JsonConvert.DeserializeObject<OrderDto>(response.Result.ToString());
					return View(new OrderRazorModel
					{
						Order = orderDto,
						ViewType = SD.ViewType.Info
					});
				}
			}
			else if (viewType == SD.ViewType.Create)
			{
				return View(new OrderRazorModel
				{
                    ViewType = SD.ViewType.Create
				});
			}
			return NotFound();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> OrderCreate(OrderRazorModel orderRazorModel)
		{
			if (ModelState.IsValid)
			{
				var response = await _orderService.CreateOrderAsync(orderRazorModel.Order);
				if (response.IsSuccess)
				{
					return RedirectToAction(nameof(OrdersListIndex));
				}
			}
			return View(nameof(OrderIndex), orderRazorModel);
		}
    }
}
