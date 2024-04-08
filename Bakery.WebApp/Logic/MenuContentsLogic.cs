using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.WebApp.Logic;
public class MenuContentsLogic(IItemTypeService _itemservice, ICategoryService _categoryservice, ISizeService _sizeservice)
{
    public List<Size> sizes { get; set; }
    public List<Category> categories { get ; set; }
    public List<Itemtype> items { get; set; }
    public List<Itemtype> filterItems { get; set; }
    public async Task<bool> InitializeAsync()
    {
        sizes = (await _sizeservice.GetAllSizes()).ToList<Size>();
        categories = (await _categoryservice.GetAllCategories()).ToList<Category>();
        items = (await _itemservice.GetAllItemtypes()).ToList<Itemtype>();
        FilterSelection();

        // Return a completed task
        return true;
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