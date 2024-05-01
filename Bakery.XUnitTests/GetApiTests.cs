using Bakery.WebApp.Data;
using FluentAssertions;
using System.Net.Http.Json;

namespace BakeryTests;

public class GetApiTests : IClassFixture<BakeryWebAPIFactory>
{
    BakeryWebAPIFactory _factory { get; set; }
    public GetApiTests(BakeryWebAPIFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async void GetSizesTest()
    {
        using var client = _factory.CreateDefaultClient();

        // Act
        var getsizes = await client.GetAsync("size/sizes");

        // Assert
        getsizes.Should().NotBeNull();
    }

    [Fact]
    public async void GetItemTypesTest()
    {
        using var client = _factory.CreateDefaultClient();

        // Act
        var getitemtypes = await client.GetAsync("itemtype/itemtypes");

        // Assert
        getitemtypes.Should().NotBeNull();
    }

    [Fact]
    public async void GetCustomItemsTest()
    {
        using var client = _factory.CreateDefaultClient();

        // Act
        var getcustomitems = await client.GetAsync("customitem/customitems");

        // Assert
        getcustomitems.Should().NotBeNull();
    }

    [Fact]
    public async void GetFavoriteItemsTest()
    {
        using var client = _factory.CreateDefaultClient();

        // Act
        var getfavoriteitems = await client.GetAsync("favoriteitem/favoriteitems");

        // Assert
        getfavoriteitems.Should().NotBeNull();
    }

    [Fact]
    public async void GetToppingsTest()
    {
        using var client = _factory.CreateDefaultClient();

        // Act
        var gettoppings = await client.GetAsync("topping/toppings");

        // Assert
        gettoppings.Should().NotBeNull();
    }
}

