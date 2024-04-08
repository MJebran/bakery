using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.WebApp.Logic;
public class MenuContentsLogic : IMenuContentsLogic
{
    public List<Size> sizes { get; set; }
    public List<Category> categories { get ; set; }
    public List<Itemtype> items { get; set; }
    public List<Itemtype> filterItems { get; set; }

    public MenuContentsLogic(IItemTypeService _itemservice, ICategoryService _categoryservice, ISizeService _sizeservice)
    {
        InitializeAsync(_itemservice, _categoryservice, _sizeservice).Wait();
    }
    private async Task InitializeAsync(IItemTypeService _itemservice, ICategoryService _categoryservice, ISizeService _sizeservice)
    {
        sizes = (await _sizeservice.GetAllSizes()).ToList<Size>();
        categories = (await _categoryservice.GetAllCategories()).ToList<Category>();
        items = (await _itemservice.GetAllItemtypes()).ToList<Itemtype>();
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