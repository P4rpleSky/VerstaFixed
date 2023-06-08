using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Versta.OrderApi.Models.Dtos;

public partial class OrderDto
{
    public int Id { get; set; }

    public string CargoWeightStr { get; set; } = null!;

    public DateTime PickupDate { get; set; }

    public virtual AddressDto SenderAddress { get; set; } = null!;

    public virtual AddressDto RecipientAddress { get; set; } = null!;
}
