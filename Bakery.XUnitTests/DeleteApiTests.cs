using Bakery.WebApp.Data;
using FluentAssertions;
using System.Net.Http.Json;

namespace BakeryTests
{
    public class DeleteApiTests : IClassFixture<BakeryWebAPIFactory>
    {
        BakeryWebAPIFactory _factory { get; set; }
        public DeleteApiTests(BakeryWebAPIFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void DeleteItemTypeTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var product = new Itemtype()
            {
                ItemTypeId = 1,
                ItemName = "Test1",
                ItemPrice = 1,
                ItmeCalories = 1,
                ItemWeight = 1,
                ItemDescription = "Test1",
                CategoryId = 1,
                SizeId = 1

            };
            //Act itemtype/add/itemtype
            await client.PostAsJsonAsync("api/itemtype/add/itemtype", product);
            await client.DeleteAsync($"api/itemtype/delete/{product.ItemTypeId}");

            var itemtypes = await client.GetAsync("api/itemtype/itemtypes");

            //Assert
            itemtypes.Should().NotBeNull();
        }

         [Fact]
        public async void DeleteCustomItemToppingTest()
        {
            using var client = _factory.CreateDefaultClient();
            
            //Arrange
            var customItemTopping = new Customitemtopping()
            {
                CustomItemToppingId = 1,
                CustomItem = new Customitem(),
                CustomItemToppingQuantity = 2
            };

            //Act
            await client.PostAsJsonAsync("api/customeitemtopping/add/custometoppingItem", customItemTopping);
            await client.DeleteAsync($"api/customeitemtopping/delete/{customItemTopping.CustomItemToppingId}");

            var itemtypes = await client.GetAsync("api/customeitemtopping/custometoppingitem");

            //Assert
            itemtypes.Should().NotBeNull();
        }

         [Fact]
        public async void DeleteFavoriteItemTest()
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

            // Act
            await client.DeleteAsync($"api/favoriteitem/delete/{favoriteItem.FavoriteitemId}");
            var getFavoriteItems = await client.GetAsync("api/favoriteitem/favoriteitems");

            // Assert
            getFavoriteItems.Should().NotBeNull();
        }

        [Fact]
        public async void DeleteUserTest()
        {
            using var client = _factory.CreateDefaultClient();

            // Arrange
            var user = new User()
            {
                UserId = 1,
                UserName = "Test1",
            };
            await client.PostAsJsonAsync("api/user/add/user", user);

            // Act
            await client.DeleteAsync($"api/user/delete/{user.UserId}");
            var getUsers = await client.GetAsync("api/user/users");

            // Assert
            getUsers.Should().NotBeNull();
        }


    }

}
