using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.WebApp.Data;

public partial class Itemtype
{
    [Required(ErrorMessage = "Item Id is required.")] 
    public int ItemTypeId { get; set; }

    [Required(ErrorMessage = "Item Name is required.")] 
    public string? ItemName { get; set; }

    [Required(ErrorMessage = "Item Price is required.")] 
    public decimal? ItemPrice { get; set; }

    [Required(ErrorMessage = "Item Calories is required.")] 
    public int? ItmeCalories { get; set; }

    [Required(ErrorMessage = "Item Weight is required.")] 
    public decimal? ItemWeight { get; set; }

    [Required(ErrorMessage = "Item Description is required.")] 
    public string? ItemDescription { get; set; }

    [Range(1, 100000, ErrorMessage = "Item Category is required")]
    public int CategoryId { get; set; }

    [Range(1, 100000, ErrorMessage = "Item Size is required")]
    public int SizeId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Customitem> Customitems { get; set; } = new List<Customitem>();

    public virtual ICollection<Favoriteitem> Favoriteitems { get; set; } = new List<Favoriteitem>();

    public virtual Size Size { get; set; } = null!;
}
