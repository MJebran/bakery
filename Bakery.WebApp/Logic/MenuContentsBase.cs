using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Components;

namespace Bakery.WebApp.Logic;

public class MenuContentsBase : ComponentBase
{
    protected List<Size> sizes { get; set; } = new();
    protected List<Category> categories { get ; set; } = new();
    protected List<Itemtype> items { get; set; } = new();
    public List<Itemtype> filterItems { get; set; } = new();

    [Inject]
    IItemTypeService? _itemservice {get; set;}

    [Inject]
    ICategoryService? _categoryservice {get; set;}

    [Inject]
    ISizeService? _sizeservice {get; set;}
    protected override async Task OnInitializedAsync()
    {
        categories = (await _categoryservice!.GetAllCategories()).ToList<Category>();
        sizes = (await _sizeservice!.GetAllSizes()).ToList<Size>();
        items = (await _itemservice!.GetAllItemtypes()).ToList<Itemtype>();
        FilterSelection();
    }

    public void FilterSelection(string category = "all")
    {
        if(category == "all")
        {
            filterItems = items;
        }
        else
        {
            filterItems = items.Where(item => item.Category.CategoryName == category).ToList();
        }
    }
}