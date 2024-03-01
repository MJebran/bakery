using Bakery.WebApp.Data;
using FluentAssertions;
using System.Drawing;
using System.Net.Http.Json;
using Bakery.WebApp.Data;

namespace BakeryTests
{
    public class DeleteApiTest : IClassFixture<BakeryWebAPIFactory>
    {
        HttpClient client;
        public DeleteApiTest(BakeryWebAPIFactory factory)
        {
            client = factory.CreateDefaultClient();
        }

        //[Fact]
        //public async void DeleteUserTest()
        //{
        //    //Arrange
        //    var user = new User()
        //    {
        //        UserId = 1,
        //        UserName = "Test1",
        //    };
        //    //Act 
        //    await client.PostAsJsonAsync("api/user/add/users", user);
        //    var x = await client.DeleteAsJsonAsync("api/user/delete/user", user);
        //    var getcategories = await client.GetAsync("api/user/users");

        //    //Assert
        //    getcategories.Should().BeNull();
        //}

        // write a Delete test for User






    }
    
}
