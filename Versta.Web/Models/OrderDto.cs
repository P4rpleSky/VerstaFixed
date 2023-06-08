using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Versta.Web.Arrtibutes;

namespace Versta.Web.Models;

public partial class OrderDto
{
    public int Id { get; set; }

    public int SenderAddressId { get; set; }

    public int RecipientAddressId { get; set; }

    [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
    [RegularExpression(@"([5-9]\d{0,2}|[1-4]\d{1,2})((,|\.)\d{1,3}){0,1}",
        ErrorMessage = "Вес груза должен находиться в диапазоне от 5 до 1000 кг!")]
    public string CargoWeightStr { get; set; } = null!;

    [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
    [Date("2000-01-01", format: "yyyy-MM-dd",
        ErrorMessage = "Введена недопустимая дата забора груза!")]
    public DateTime PickupDate { get; set; }

    public virtual AddressDto SenderAddress { get; set; } = null!;

    public virtual AddressDto RecipientAddress { get; set; } = null!;
}
