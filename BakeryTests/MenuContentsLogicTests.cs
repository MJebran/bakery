using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bakery.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;

namespace BakeryTests;
public class MenuContentsLogicTests : TestContext
{
    static List<Itemtype> createItemsWithCategory(List<(string name, int categoryId)> itemNameAndCategory)
    {
        List<Itemtype> items = new();
        foreach (var item in itemNameAndCategory)
        {
            items.Add(new Itemtype
            {
                ItemName = item.name,
                CategoryId = item.categoryId
            });
        }
        return items;
    }

    [Fact]
    public async void EmptyFilterWorks()
    {
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();

        // Arrange
        var cut = RenderComponent<MenuContentsBase>();

        // Act
        await cut.InvokeAsync(() => cut.Instance.FilterSelection());

        // Assert
        var filterItemsCount = cut.Instance.filterItems.Count();
        Assert.Equal(0, filterItemsCount);
    }

    [Fact]
    public async void CakeFilterWorks()
    {
        // Arrange
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();

        var itemsWithCategoryID = new List<(string, int)>{
        ("chocolate cake", 1),
        ("strawberry cake", 1),
        ("chocolate cupcake", 2),
        };

        var categories = new List<Category>(){ new Category(){CategoryId = 1, CategoryName = "cake"}, 
                                               new Category(){CategoryId = 2, CategoryName = "cupcake"}};

        var items = createItemsWithCategory(itemsWithCategoryID);

        var itemsvc = Services.GetService<IItemTypeService>();
        var catsvc = Services.GetService<ICategoryService>();

        foreach (var item in items)
        {
            await itemsvc!.AddItemtype(item);
        }

        foreach(var category in categories)
        {
            await catsvc!.AddCategory(category);
        }

        var cut = RenderComponent<MenuContentsBase>();

        // Act
        await cut.InvokeAsync(() => cut.Instance.FilterSelection("cake"));

        // Assert
        var filterItemsCount = cut.Instance.filterItems.Count();
        Assert.Equal(2, filterItemsCount);
    }

    [Fact]
    public async void CupcakeFilterWorks()
    {
        // Arrange
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();

        var itemsWithCategoryID = new List<(string, int)>{
        ("chocolate cake", 1),
        ("strawberry cake", 1),
        ("chocolate cupcake", 2),
        };

        var categories = new List<Category>(){ new Category(){CategoryId = 1, CategoryName = "cake"}, 
                                               new Category(){CategoryId = 2, CategoryName = "cupcake"}};

        var items = createItemsWithCategory(itemsWithCategoryID);

        var itemsvc = Services.GetService<IItemTypeService>();
        var catsvc = Services.GetService<ICategoryService>();


        foreach (var item in items)
        {
            await itemsvc!.AddItemtype(item);
        }
        
        foreach(var category in categories)
        {
            await catsvc!.AddCategory(category);
        }

        var cut = RenderComponent<MenuContentsBase>();

        // Act
        await cut.InvokeAsync(() => cut.Instance.FilterSelection("cupcake"));

        // Assert
        var filterItemsCount = cut.Instance.filterItems.Count();
        Assert.Equal(1, filterItemsCount);
    }

}

