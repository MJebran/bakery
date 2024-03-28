using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.WebApp.Data;

public partial class Topping
{
    public int ToppingId { get; set; }
        
    [Required(ErrorMessage = "Topping Name is required")] 
    public string? ToppingName { get; set; }

    [Required(ErrorMessage = "Topping Price is required")] 
    public decimal? ToppingPrice { get; set; }
    
    [Required(ErrorMessage = "Topping Weight is required")] 
    public decimal? ToppingWeight { get; set; }

    [Required(ErrorMessage = "Topping Calories is required")] 
    public int? ToppingCalories { get; set; }

    [Required(ErrorMessage = "Topping Unit is required")] 
    public string? ToppingUnit { get; set; }

    public virtual ICollection<Customitem> Customitems { get; set; } = new List<Customitem>();
}
