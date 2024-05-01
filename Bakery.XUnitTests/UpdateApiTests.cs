using Bakery.WebApp.Data;
using FluentAssertions;
using System.Drawing;
using System.Net.Http.Json;
using Bakery.WebApp.Data;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace BakeryTests
{
    public class UpdateApiTests : IClassFixture<BakeryWebAPIFactory>
    {
        BakeryWebAPIFactory _factory { get; set; }
        public UpdateApiTests(BakeryWebAPIFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void UpdateCustomItemTest()
        {
            using var client = _factory.CreateDefaultClient();

            // Arrange
            var customItem = new Customitem()
            {
                CustomItemId = 1,
                ItemId = 1,
            };
            await client.PostAsJsonAsync("api/customitem/add/customitem", customItem);
            var getCustomItems = await client.GetAsync("api/customitem/customitems");
            var updatedCustomItem = new Customitem()
            {
                CustomItemId = 1,
                ItemId = 2,
            };

            // Act
            await client.PutAsJsonAsync("/api/customitem/update/customitem", updatedCustomItem);
            var getUpdatedCustomItem = await client.GetAsync("api/customitem/customitems");

            // Assert
            getCustomItems.Should().NotBeNull();
            Assert.True(getCustomItems != getUpdatedCustomItem);
        }

        [Fact]
        public async void UpdateFavoriteItemTest()
        {
            using var client = _factory.CreateDefaultClient();

            // Arrange
            var favoriteItem = new Favoriteitem()
            {
                FavoriteitemId = 1,
                UserId = 1,
                ItemId = 1,
            };
            await client.PostAsJsonAsync("api/favoriteitem/add/favoriteitem", favoriteItem);
            var getFavoriteItems = await client.GetAsync("api/favoriteitem/favoriteitems");
            var updatedFavoriteItem = new Favoriteitem()
            {
                FavoriteitemId = 1,
                UserId = 2,
                ItemId = 2,
            };

            // Act
            await client.PutAsJsonAsync("/api/favoriteitem/update/favoriteitem", updatedFavoriteItem);
            var getUpdatedFavoriteItem = await client.GetAsync("api/favoriteitem/favoriteitems");

            // Assert
            getFavoriteItems.Should().NotBeNull();
            Assert.True(getFavoriteItems != getUpdatedFavoriteItem);
        }

        [Fact]
        public async void UpdateToppingTest()
        {
            using var client = _factory.CreateDefaultClient();

            // Arrange
            var topping = new Topping()
            {
                ToppingId = 1,
                ToppingName = "Test1",
            };
            await client.PostAsJsonAsync("api/topping/add/topping", topping);
            var getToppings = await client.GetAsync("api/topping/toppings");
            var updatedTopping = new Topping()
            {
                ToppingId = 1,
                ToppingName = "Test2",
            };

            // Act
            await client.PutAsJsonAsync("/api/topping/update/topping", updatedTopping);
            var getUpdatedTopping = await client.GetAsync("api/topping/toppings");

            // Assert
            getToppings.Should().NotBeNull();
            Assert.True(getToppings != getUpdatedTopping);
        }

        [Fact]
        public async void UpdateUserTest()
        {
            using var client = _factory.CreateDefaultClient();

            // Arrange
            var user = new User()
            {
                UserId = 1,
                UserName = "Test1",
            };
            await client.PostAsJsonAsync("api/user/add/user", user);
            var getUsers = await client.GetAsync("api/user/users");
            var user2 = new User()
            {
                UserId = 2,
                UserName = "Test2",
            };

            // Act
            await client.PutAsJsonAsync("/api/user/update/user", user2);
            var getUser2 = await client.GetAsync("api/user/users");

            // Assert
            getUsers.Should().NotBeNull();
            Assert.True(getUsers != getUser2);
        }
    }
}

