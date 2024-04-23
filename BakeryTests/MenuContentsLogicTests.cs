using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bakery.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;

namespace BakeryTests;
public class MenuContentsLogicTests : TestContext
{
    static List<Itemtype> createItemsWithCategory(List<(string name, string category)> itemNameAndCategory)
    {
        List<Itemtype> items = new();
        foreach (var item in itemNameAndCategory)
        {
            items.Add(new Itemtype
            {
                ItemName = item.name,
                Category = new Category { CategoryName = item.category }
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

        var itemsWithCategories = new List<(string, string)>{
        ("chocolate cake", "cake"),
        ("strawberry cake", "cake"),
        ("chocolate cupcake", "cupcake"),
        };

        var items = createItemsWithCategory(itemsWithCategories);

        var svc = Services.GetService<IItemTypeService>();

        foreach (var item in items)
        {
            await svc.AddItemtype(item);
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

        var itemsWithCategories = new List<(string, string)>{
        ("chocolate cake", "cake"),
        ("strawberry cake", "cake"),
        ("chocolate cupcake", "cupcake"),
        };

        var items = createItemsWithCategory(itemsWithCategories);

        var svc = Services.GetService<IItemTypeService>();

        foreach (var item in items)
        {
            await svc.AddItemtype(item);
        }

        var cut = RenderComponent<MenuContentsBase>();

        // Act
        await cut.InvokeAsync(() => cut.Instance.FilterSelection("cupcake"));

        // Assert
        var filterItemsCount = cut.Instance.filterItems.Count();
        Assert.Equal(1, filterItemsCount);
    }

}

