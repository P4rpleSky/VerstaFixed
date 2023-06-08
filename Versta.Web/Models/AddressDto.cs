using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Versta.Web.Arrtibutes;

namespace Versta.Web.Models;

public partial class AddressDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
    [MaxLength(32)]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
    [MaxLength(37)]
    [Street(ErrorMessage = "Название улицы не должно содержать запятых!")]
    public string StreetName { get; set; } = null!;

    [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
    [Range(1, 1000, ErrorMessage = "Введён некорректный номер дома!")]
    public int HouseNumber { get; set; }

    [MaxLength(8)]
    public string? Block { get; set; }

    [Range(1, 100, ErrorMessage = "Введён некорректный номер корпуса!")]
    public int? BuildingNumber { get; set; }

    [Range(1, 10000, ErrorMessage = "Введён некорректный номер квартиры!")]
    public int? FlatNumber { get; set; }

	public string? ViewString { get; set; } = null!;
}
