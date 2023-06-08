using AutoMapper;
using System.Text;
using Versta.OrderApi.Models;
using Versta.OrderApi.Models.Dtos;

namespace Versta.OrderApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Order, OrderDto>()
                    .AfterMap((order, orderDto) =>
                    {
                        orderDto.CargoWeightStr = order.CargoWeight.ToString();
                    });
                config.CreateMap<OrderDto, Order>()
                    .AfterMap((orderDto, order) =>
                    {
                        order.CargoWeight = decimal.Parse(orderDto.CargoWeightStr.Replace('.', ','));
					});
                config.CreateMap<Address, AddressDto>()
	                .AfterMap((address, addressDto) =>
	                {
						var adressList = new List<string>();
						adressList.Add(address.StreetName);
                        adressList.Add("д. " + address.HouseNumber);

                        if (address.Block is not null)
	                        adressList.Add("к. " + address.Block);

                        if (address.BuildingNumber is not null)
	                        adressList.Add("стр. " + address.BuildingNumber);

                        if (address.FlatNumber is not null)
	                        adressList.Add("кв. " + address.FlatNumber);

						addressDto.ViewString = string.Join(", ", adressList);
	                })
	                .ReverseMap();
            });
            return mappingConfig;
        }
    }
}
