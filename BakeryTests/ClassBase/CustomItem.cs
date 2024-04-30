using Bunit;
using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Bakery.ClassLibrary.Services;
using BakeryTests.ServiceTests;
using Bakery.WebApp.Services;
using Microsoft.AspNetCore.Authentication;
using Bakery.WebApp.Authentication;
using FluentAssertions;
public class CustomItem : TestContext
{
    [Fact]
    public void IncreaseToppingAmount_CLick_ButtonIncrease(){
        // Arrange
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<IUserService, UserServiceTest>();
        Services.AddSingleton<IRoleService, RoleServiceTest>();
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<ICustomItemService, CustomItemServiceTest>();
        Services.AddSingleton<IPurchaseService, PurchaseServiceTest>();
        Services.AddSingleton<IItemPurchaseService, ItemPurchaseServiceTest>();
        Services.AddSingleton<ICustomeItemToppingService, CustomeItemToppingServiceTest>();
        Services.AddSingleton<IBakeryAutheticationService, BakeryAutheticationServiceTest>();

        var baseItem = new Itemtype
        {
            ItemTypeId = 1,
            ItemPrice = 5.0m,
        };

        var cut = RenderComponent<CustomizeItemBase>();

        var topping = new Topping();

        // Act
        cut.InvokeAsync(() => cut.Instance.IncreaseToppingAmount(topping));
        // Assert
        var filterItemsCount = cut.Instance.toppingToQuantity.Count();
        Assert.Equal(0, filterItemsCount);
    }

    [Fact]
    public async Task DecreaseToppingAmount_Click_ButtonDecreasesTopping()
    {
        // Arrange
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<IUserService, UserServiceTest>();
        Services.AddSingleton<IRoleService, RoleServiceTest>();
        Services.AddSingleton<ICustomItemService, CustomItemServiceTest>();
        Services.AddSingleton<IPurchaseService, PurchaseServiceTest>();
        Services.AddSingleton<IItemPurchaseService, ItemPurchaseServiceTest>();
        Services.AddSingleton<ICustomeItemToppingService, CustomeItemToppingServiceTest>();
        Services.AddSingleton<IBakeryAutheticationService, BakeryAutheticationServiceTest>();

        var baseItem = new Itemtype
        {
            ItemTypeId = 1,
            ItemPrice = 5.0m,
        };

        var cut = RenderComponent<CustomizeItemBase>();

        // Act
        cut.InvokeAsync(() => cut.Instance.IncreaseToppingAmount(new Topping()));
        cut.InvokeAsync(() => cut.Instance.DecreaseToppingAmount(new Topping()));
        var filterItemsCount = cut.Instance.toppingToQuantity.Count();
        // Assert
        Assert.Equal(0, filterItemsCount);
    }
    [Fact]
    public async Task AddToCart_Click_ButtonAddsToCart()
    {
        // Arrange
        var authService = new BakeryAutheticationServiceTest(
            new UserServiceTest(),
            new RoleServiceTest()
        );

        Services.AddSingleton<IBakeryAutheticationService>(authService);
        Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<ICustomItemService, CustomItemServiceTest>();
        Services.AddSingleton<IPurchaseService, PurchaseServiceTest>();
        Services.AddSingleton<IItemPurchaseService, ItemPurchaseServiceTest>();
        Services.AddSingleton<ICustomeItemToppingService, CustomeItemToppingServiceTest>();

        await authService.RegisterUserAsync("test@example.com", "Test", "User");

        var baseItem = new Itemtype
        {
            ItemTypeId = 1,
            ItemPrice = 5.0m,
        };

        var cut = RenderComponent<CustomizeItemBase>();

        // Act
        await cut.InvokeAsync(() => cut.Instance.AddToCart());

        // Assert
        var navElement = cut.Instance.NavigationManager;
        var currentUrl = navElement.Uri;

        Assert.Equal("http://localhost/cart/0", currentUrl);
    }
}