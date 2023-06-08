using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Versta.OrderApi.Models;

public partial class Order
{
    public int Id { get; set; }

    public int SenderAddressId { get; set; }

    public int RecipientAddressId { get; set; }

    public decimal CargoWeight { get; set; }
    
    public DateTime PickupDate { get; set; }

    public virtual Address RecipientAddress { get; set; } = null!;

    public virtual Address SenderAddress { get; set; } = null!;
}
