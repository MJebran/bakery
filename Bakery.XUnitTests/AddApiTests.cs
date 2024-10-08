using Bakery.WebApp.Data;
using FluentAssertions;
using System.Net.Http.Json;

namespace BakeryTests
{
    public class AddApiTests : IClassFixture<BakeryWebAPIFactory>
    {
        BakeryWebAPIFactory _factory { get; set; }
        public AddApiTests(BakeryWebAPIFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void AddSizeTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var size = new Bakery.WebApp.Data.Size()
            {
                SizeId = 1,
                SizeName = "Test1",
                Itemtypes = new List<Itemtype>()
            };

            //Act 
            await client.PostAsJsonAsync("size/add/size", size);
            var getsizes = await client.GetAsync("size/sizes");

            //Assert
            getsizes.Should().NotBeNull();
        }

        [Fact]
        public async void AddItemTypeTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var itemtype = new Itemtype()
            {
                ItemTypeId = 1,
                ItemName = "Test1",
                ItemPrice = 1,
                ItmeCalories = 1,
                ItemWeight = 1,
                ItemDescription = "this is just a test",
                SizeId = 1,
                CategoryId = 1,
                Category = new Category(),
                Size = new Bakery.WebApp.Data.Size(),
                Customitems = new List<Customitem>(),
                Favoriteitems = new List<Favoriteitem>()

            };

            //Act 
            await client.PostAsJsonAsync("itemtype/add/itemtype", itemtype);
            var getitemtypes = await client.GetAsync("itemtype/itemtypes");

            //Assert
            getitemtypes.Should().NotBeNull();
        }

        [Fact]
        public async void AddCustomItemTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var customitem = new Customitem()
            {
                CustomItemId = 1,
                ItemId = 1,
                Item = new Itemtype(),
                Itempurchases = new List<Itempurchase>(),
            };

            //Act 
            await client.PostAsJsonAsync("customitem/add/customitem", customitem);
            var getcustomitems = await client.GetAsync("customitem/customitems");

            //Assert
            getcustomitems.Should().NotBeNull();
        }

        [Fact]
        public async void AddFavoriteItemTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var favoriteitem = new Favoriteitem()
            {
                FavoriteitemId = 1,
                UserId = 1,
                ItemId = 1,
                Item = new Itemtype()
            };

            //Act 
            await client.PostAsJsonAsync("favoriteitem/add/favoriteitem", favoriteitem);
            var getfavoriteitems = await client.GetAsync("favoriteitem/favoriteitems");

            //Assert
            getfavoriteitems.Should().NotBeNull();
        }

        [Fact]
        public async void AddToppingTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var topping = new Topping()
            {
                ToppingId = 1,
                ToppingName = "Test1",
                ToppingPrice = 1,
                ToppingCalories = 1,
                ToppingWeight = 1,
                //Customitems = new List<Customitem>()
            };

            //Act 
            await client.PostAsJsonAsync("topping/add/topping", topping);
            var gettoppings = await client.GetAsync("topping/toppings");

            //Assert
            gettoppings.Should().NotBeNull();
        }

        [Fact]
        public async void AddUserTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var user = new User()
            {
                UserId = 1,
                UserName = "Test1",
                UserEmail = "Test1",
                UserPhone = 857310000,
                UserRoleId = 1,
                Favoriteitems = new List<Favoriteitem>()
            };

            //Act 
            await client.PostAsJsonAsync("user/add/user", user);
            var getusers = await client.GetAsync("user/users");

            //Assert
            getusers.Should().NotBeNull();
        }

        [Fact]
        public async void AddRoleTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var role = new Role()
            {
                RoleId = 1,
                RoleName = "Test1",
                RoleDescription = "this is just a test",
                Users = new List<User>()
            };

            //Act 
            await client.PostAsJsonAsync("role/add/role", role);
            var getroles = await client.GetAsync("role/roles");

            //Assert
            getroles.Should().NotBeNull();
        }

        [Fact]
        public async void AddItemPurchaseTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var itempurchase = new Itempurchase()
            {
                ItempurchaseId = 1,
                ItempurchaseQuantity = 1,
                ItempurchaseItemId = 1,
                PurchaseId = 1,
                ItempurchaseItem = new Customitem(),
                Purchase = new Purchase(),
            };

            //Act 
            await client.PostAsJsonAsync("itempurchase/add/itempurchase", itempurchase);
            var getitempurchases = await client.GetAsync("itempurchase/itempurchases");

            //Assert
            getitempurchases.Should().NotBeNull();
        }

        [Fact]
        public async void AddPurchaseTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var purchase = new Purchase()
            {
                PurchaseId = 1,
                PurcahseDate = new DateOnly(),
                Ispayed = true,
                PurchaseUserId = 1,
                Itempurchases = new List<Itempurchase>(),
                PurchaseUser = new User()
            };

            //Act 
            await client.PostAsJsonAsync("purchase/add/purchase", purchase);
            var getpurchases = await client.GetAsync("purchase/purchases");

            //Assert
            getpurchases.Should().NotBeNull();
        }

        [Fact]
        public async void AddItemTest()
        {
            using var client = _factory.CreateDefaultClient();

            //Arrange
            var item = new Itemtype()
            {
                ItemTypeId = 1,
                ItemName = "Test1",
                ItemPrice = 1,
                ItmeCalories = 1,
                ItemWeight = 1,
                ItemDescription = "this is just a test",
                SizeId = 1,
                CategoryId = 1,
                Category = new Category(),
                Size = new Size(),
                Customitems = new List<Customitem>(),
                Favoriteitems = new List<Favoriteitem>(),
            };

            //Act 
            await client.PostAsJsonAsync("item/add/item", item);
            var getitems = await client.GetAsync("item/items");

            //Assert
            getitems.Should().NotBeNull();
        }
    }
}