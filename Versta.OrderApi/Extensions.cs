using Microsoft.EntityFrameworkCore;
using Versta.OrderApi.DbContexts;
using Versta.OrderApi.Models;
using Versta.OrderApi.Models.Dtos;

namespace Versta.OrderApi
{
    public static class Extensions
    {
        public static IQueryable<Order> GetOrdersSummary(this VerstaDbContext db)
        {
            return from order in db.Orders
                join senderAddress in db.Addresses on order.SenderAddressId equals senderAddress.Id
                join recipientAddress in db.Addresses on order.RecipientAddressId equals recipientAddress.Id
                select new Order
                {
                    Id = order.Id,
                    SenderAddressId = order.SenderAddressId,
                    SenderAddress = senderAddress,
                    RecipientAddressId = order.RecipientAddressId,
                    RecipientAddress = recipientAddress,
                    CargoWeight = order.CargoWeight,
                    PickupDate = order.PickupDate
                };
        }
    }
}
