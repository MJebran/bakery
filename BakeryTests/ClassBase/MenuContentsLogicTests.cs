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

        foreach (var category in categories)
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

        foreach (var category in categories)
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

    [Fact]
public async void DessertFilterWorks()
{
    // Arrange
    Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
    Services.AddSingleton<ICategoryService, CategoryServiceTest>();
    Services.AddSingleton<ISizeService, SizeServiceTest>();

    var itemsWithCategoryID = new List<(string, int)>{
        ("cheesecake", 9),
        ("apple pie", 9),
        ("brownie", 10),
    };

    var categories = new List<Category>(){ new Category(){CategoryId = 9, CategoryName = "dessert"},
                                            new Category(){CategoryId = 10, CategoryName = "brownie"}};

    var items = createItemsWithCategory(itemsWithCategoryID);

    var itemsvc = Services.GetService<IItemTypeService>();
    var catsvc = Services.GetService<ICategoryService>();

    foreach (var item in items)
    {
        await itemsvc!.AddItemtype(item);
    }

    foreach (var category in categories)
    {
        await catsvc!.AddCategory(category);
    }

    var cut = RenderComponent<MenuContentsBase>();

    // Act
    await cut.InvokeAsync(() => cut.Instance.FilterSelection("dessert"));

    // Assert
    var filterItemsCount = cut.Instance.filterItems.Count();
    Assert.Equal(2, filterItemsCount);
}

[Fact]
public async void RollFilterWorks()
{
    // Arrange
    Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
    Services.AddSingleton<ICategoryService, CategoryServiceTest>();
    Services.AddSingleton<ISizeService, SizeServiceTest>();

    var itemsWithCategoryID = new List<(string, int)>{
        ("cinnamon roll", 11),
        ("croissant", 11),
        ("danish", 12),
    };

    var categories = new List<Category>(){ new Category(){CategoryId = 11, CategoryName = "roll"},
                                            new Category(){CategoryId = 12, CategoryName = "danish"}};

    var items = createItemsWithCategory(itemsWithCategoryID);

    var itemsvc = Services.GetService<IItemTypeService>();
    var catsvc = Services.GetService<ICategoryService>();

    foreach (var item in items)
    {
        await itemsvc!.AddItemtype(item);
    }

    foreach (var category in categories)
    {
        await catsvc!.AddCategory(category);
    }

    var cut = RenderComponent<MenuContentsBase>();

    // Act
    await cut.InvokeAsync(() => cut.Instance.FilterSelection("roll"));

    // Assert
    var filterItemsCount = cut.Instance.filterItems.Count();
    Assert.Equal(2, filterItemsCount);
}

[Fact]
public async void LoafFilterWorks()
{
    // Arrange
    Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
    Services.AddSingleton<ICategoryService, CategoryServiceTest>();
    Services.AddSingleton<ISizeService, SizeServiceTest>();

    var itemsWithCategoryID = new List<(string, int)>{
        ("baguette", 13),
        ("sourdough", 13),
        ("rye bread", 14),
    };

    var categories = new List<Category>(){ new Category(){CategoryId = 13, CategoryName = "loaf"},
                                            new Category(){CategoryId = 14, CategoryName = "rye bread"}};

    var items = createItemsWithCategory(itemsWithCategoryID);

    var itemsvc = Services.GetService<IItemTypeService>();
    var catsvc = Services.GetService<ICategoryService>();

    foreach (var item in items)
    {
        await itemsvc!.AddItemtype(item);
    }

    foreach (var category in categories)
    {
        await catsvc!.AddCategory(category);
    }

    var cut = RenderComponent<MenuContentsBase>();

    // Act
    await cut.InvokeAsync(() => cut.Instance.FilterSelection("loaf"));

    // Assert
    var filterItemsCount = cut.Instance.filterItems.Count();
    Assert.Equal(2, filterItemsCount);
}


}

