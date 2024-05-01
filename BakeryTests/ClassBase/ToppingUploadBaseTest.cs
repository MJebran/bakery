using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bakery.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using FluentAssertions;
using Bakery.WebApp.Telemetry;

namespace BakeryTests;

public class ToppingUploadBaseTest : TestContext
{
    [Fact]
    public async void CanAddSprinkleTopping()
    {
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<PageLogger>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ToppingUploadBase>();

        // Act
        var testItem = new Topping { ToppingId = 1, ToppingName = "sprinkles" };
        cut.Instance.ChangeToppingToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddTopping());

        // Assert
        var ToppingService = Services.GetRequiredService<IToppingService>();
        var Toppings = ToppingService.GetAllToppings();

        Toppings.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddChocolateTopping()
    {
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<PageLogger>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ToppingUploadBase>();

        // Act
        var testItem = new Topping { ToppingId = 1, ToppingName = "chocolate" };
        cut.Instance.ChangeToppingToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddTopping());

        // Assert
        var ToppingService = Services.GetRequiredService<IToppingService>();
        var Toppings = ToppingService.GetAllToppings();

        Toppings.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddCaramelTopping()
    {
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<PageLogger>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ToppingUploadBase>();

        // Act
        var testItem = new Topping { ToppingId = 1, ToppingName = "caramel" };
        cut.Instance.ChangeToppingToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddTopping());

        // Assert
        var ToppingService = Services.GetRequiredService<IToppingService>();
        var Toppings = ToppingService.GetAllToppings();

        Toppings.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddNutsTopping()
    {
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<PageLogger>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ToppingUploadBase>();

        // Act
        var testItem = new Topping { ToppingId = 1, ToppingName = "nuts" };
        cut.Instance.ChangeToppingToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddTopping());

        // Assert
        var ToppingService = Services.GetRequiredService<IToppingService>();
        var Toppings = ToppingService.GetAllToppings();

        Toppings.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddFudgeTopping()
    {
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<PageLogger>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ToppingUploadBase>();

        // Act
        var testItem = new Topping { ToppingId = 1, ToppingName = "fudge" };
        cut.Instance.ChangeToppingToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddTopping());

        // Assert
        var ToppingService = Services.GetRequiredService<IToppingService>();
        var Toppings = ToppingService.GetAllToppings();

        Toppings.Should().NotBeNull();
    }

    [Fact]
    public async void CanAddFruitTopping()
    {
        Services.AddSingleton<IToppingService, ToppingServiceTest>();
        Services.AddSingleton<PageLogger>();
        Services.AddSingleton<IBlobStorageService, BlobServiceTest>();

        // Arrange
        var cut = RenderComponent<ToppingUploadBase>();

        // Act
        var testItem = new Topping { ToppingId = 1, ToppingName = "fruit" };
        cut.Instance.ChangeToppingToAdd(testItem);

        await cut.InvokeAsync(() => cut.Instance.AddTopping());

        // Assert
        var ToppingService = Services.GetRequiredService<IToppingService>();
        var Toppings = ToppingService.GetAllToppings();

        Toppings.Should().NotBeNull();
    }

}