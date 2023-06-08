using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Versta.OrderApi.Models.Dtos;

public partial class AddressDto
{
    
    public string City { get; set; } = null!;

    public string StreetName { get; set; } = null!;

    public int HouseNumber { get; set; }

    public string? Block { get; set; }

    public int? BuildingNumber { get; set; }

    public int? FlatNumber { get; set; }

    public string ViewString { get; set; } = null!;
}
