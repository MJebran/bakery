using Bakery.WebApp.Data;
using FluentAssertions;
using System.Drawing;
using System.Net.Http.Json;
using Bakery.WebApp.Data;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace BakeryTests
{
    public class DeleteApiTests : IClassFixture<BakeryWebAPIFactory>
    {
        HttpClient client;
        public DeleteApiTests(BakeryWebAPIFactory factory)
        {
            client = factory.CreateDefaultClient();
        }

        // [Fact]
        // public async void DeleteUserTest()
        // {
        //     //Arrange
        //     var user = new User()
        //     {
        //         UserId = 1,
        //         UserName = "Test1",
        //     };
        //     //Act 
        //     await client.PostAsJsonAsync("api/user/add/user", user);
        //     var userSerialized = System.Text.Json.JsonSerializer.Serialize(user);
        //     var requestContent = new HttpRequestMessage(HttpMethod.Delete, "api/user/delete/user");
        //     requestContent.Content = new StringContent(JsonConvert.SerializeObject(userSerialized), Encoding.UTF8, "application/json");
        //     await this.client.SendAsync(requestContent);
        //     var getcategories = await client.GetFromJsonAsync<List<User>>("api/user/users");

        //     //Assert
        //     getcategories.Should().BeEmpty();
        // }

        [Fact]
        public async void DeleteItemTypeTest()
        {
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
            var productSerialized = System.Text.Json.JsonSerializer.Serialize(product);
            var requestContent = new HttpRequestMessage(HttpMethod.Delete, "api/itemtype/delete/itemtype");
            requestContent.Content = new StringContent(JsonConvert.SerializeObject(productSerialized), Encoding.UTF8, "application/json");
            await this.client.SendAsync(requestContent);
            var getcategories = await client.GetFromJsonAsync<List<Itemtype>>("api/itemtype/itemtypes");

            //Assert
            getcategories.Should().BeEmpty();
        }

        //[Fact]
        //public async void DeleteCategoryTest()
        //{
        //    //Arrange
        //    var category = new Category()
        //    {
        //        CategoryId = 1,
        //        CategoryName = "Test1",
        //        CategoryDescription = "Test1"
        //    };
        //    //Act 
        //    await client.PostAsJsonAsync("api/category/add/category", category);
        //    var categorySerialized = System.Text.Json.JsonSerializer.Serialize(category);
        //    var requestContent = new HttpRequestMessage(HttpMethod.Delete, "api/category/delete/category");
        //    requestContent.Content = new StringContent(JsonConvert.SerializeObject(categorySerialized), Encoding.UTF8, "application/json");
        //    await this.client.SendAsync(requestContent);
        //    var getcategories = await client.GetFromJsonAsync<List<Category>>("api/category/categories");

        //    //Assert
        //    getcategories.Should().BeEmpty();
        //}










    }

}
