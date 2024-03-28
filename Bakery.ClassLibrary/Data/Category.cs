using System.ComponentModel.DataAnnotations;

namespace Bakery.WebApp.Data;

public partial class Category
{
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "Category Name is required")] 
    public string? CategoryName { get; set; }

    [Required(ErrorMessage = "Category Description is required")] 
    public string? CategoryDescription { get; set; }

    public virtual ICollection<Itemtype> Itemtypes { get; set; } = new List<Itemtype>();
}
