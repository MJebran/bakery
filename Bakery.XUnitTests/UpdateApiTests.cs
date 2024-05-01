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
        HttpClient client;
        public UpdateApiTests(BakeryWebAPIFactory factory)
        {
            client = factory.CreateDefaultClient();
        }

        // [Fact]
        // public async void UpdateUserTest()
        // {
        //     //Arrange
        //     var user = new User()
        //     {
        //         UserId = 1,
        //         UserName = "Test1",
        //     };
        //     //Act 
        //     await client.PostAsJsonAsync("api/user/add/user", user);
        //     var getUsers = await client.GetFromJsonAsync<IEnumerable<User>>("api/user/users");
        //     var user2 = new User()
        //     {
        //         UserId = 2,
        //         UserName = "Teste2",
        //     };
        //     await client.PutAsJsonAsync("/api/user/update/user", user2);
        //     var getUser2 = await client.GetFromJsonAsync< IEnumerable <User>> ("api/user/users");

        //     //Assert
        //     getUsers.Should().NotBeNull(); // this should be true
        //     getUsers.Should().NotBeSameAs(getUser2);
        // }
    }

}
