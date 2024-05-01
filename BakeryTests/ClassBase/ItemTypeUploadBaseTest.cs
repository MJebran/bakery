using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bakery.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using FluentAssertions;

namespace BakeryTests;

public class ItemTypeUploadBaseTest : TestContext
{
    [Fact]
    public async void CanAddAnItem()
    {
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ItemTypeUploadBase>();

        // Act
        var testItem = new Itemtype { ItemTypeId = 1, ItemName = "test item" };
        cut.Instance.ChangeItemToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddItem());

        // Assert
        var ItemTypeService = Services.GetRequiredService<IItemTypeService>();
        var itemTypes = ItemTypeService.GetAllItemtypes();

        itemTypes.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddCakeItem()
    {
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ItemTypeUploadBase>();

        // Act
        var testItem = new Itemtype { ItemTypeId = 1, ItemName = "cake item" };
        cut.Instance.ChangeItemToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddItem());

        // Assert
        var ItemTypeService = Services.GetRequiredService<IItemTypeService>();
        var itemTypes = ItemTypeService.GetAllItemtypes();

        itemTypes.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddBreadItem()
    {
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ItemTypeUploadBase>();

        // Act
        var testItem = new Itemtype { ItemTypeId = 1, ItemName = "bread item" };
        cut.Instance.ChangeItemToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddItem());

        // Assert
        var ItemTypeService = Services.GetRequiredService<IItemTypeService>();
        var itemTypes = ItemTypeService.GetAllItemtypes();

        itemTypes.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddPastryItem()
    {
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ItemTypeUploadBase>();

        // Act
        var testItem = new Itemtype { ItemTypeId = 1, ItemName = "pastry item" };
        cut.Instance.ChangeItemToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddItem());

        // Assert
        var ItemTypeService = Services.GetRequiredService<IItemTypeService>();
        var itemTypes = ItemTypeService.GetAllItemtypes();

        itemTypes.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddDessertItem()
    {
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ItemTypeUploadBase>();

        // Act
        var testItem = new Itemtype { ItemTypeId = 1, ItemName = "dessert item" };
        cut.Instance.ChangeItemToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddItem());

        // Assert
        var ItemTypeService = Services.GetRequiredService<IItemTypeService>();
        var itemTypes = ItemTypeService.GetAllItemtypes();

        itemTypes.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddRollItem()
    {
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<ICategoryService, CategoryServiceTest>();
        Services.AddSingleton<ISizeService, SizeServiceTest>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ItemTypeUploadBase>();

        // Act
        var testItem = new Itemtype { ItemTypeId = 1, ItemName = "roll item" };
        cut.Instance.ChangeItemToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddItem());

        // Assert
        var ItemTypeService = Services.GetRequiredService<IItemTypeService>();
        var itemTypes = ItemTypeService.GetAllItemtypes();

        itemTypes.Should().NotBeNull();
    }

}