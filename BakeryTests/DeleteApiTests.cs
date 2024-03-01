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

        [Fact]
        public async void DeleteUserTest()
        {
            //Arrange
            var user = new User()
            {
                UserId = 1,
                UserName = "Test1",
            };
            //Act 
            await client.PostAsJsonAsync("api/user/add/user", user);
            var userSerialized = System.Text.Json.JsonSerializer.Serialize(user);
            var requestContent = new HttpRequestMessage(HttpMethod.Delete, "api/user/delete/user");
            requestContent.Content = new StringContent(JsonConvert.SerializeObject(userSerialized), Encoding.UTF8, "application/json");
            await this.client.SendAsync(requestContent);
            //var requestContent = new StringContent(userSerialized, Encoding.UTF8, "application/json");
            //var x = await client.DeleteAsync("api/user/delete/user", requestContent);
            var getcategories = await client.GetFromJsonAsync<List<User>>("api/user/users");

            //Assert
            getcategories.Should().BeEmpty();
        }










    }
    
}
