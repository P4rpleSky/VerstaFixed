using System;
using System.Collections.Generic;

namespace Versta.OrderApi.Models;

public partial class Address
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string StreetName { get; set; } = null!;

    public int HouseNumber { get; set; }

    public string? Block { get; set; }

    public int? BuildingNumber { get; set; }

    public int? FlatNumber { get; set; }

    public virtual ICollection<Order> OrderRecipientAddresses { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderSenderAddresses { get; set; } = new List<Order>();
}
