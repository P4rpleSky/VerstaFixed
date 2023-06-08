namespace Versta.Web.Models
{
	public class OrderRazorModel
	{
		public OrderDto Order { get; set; } = new OrderDto();
		public SD.ViewType ViewType { get; set; }
	}
}
