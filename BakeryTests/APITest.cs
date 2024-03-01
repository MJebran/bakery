using Bakery.WebApp.Data;
using FluentAssertions;
using System.Net.Http.Json;

namespace BakeryTests
{
    public class APITest : IClassFixture<BakeryWebAPIFactory>
    {
        HttpClient client;
        public APITest(BakeryWebAPIFactory factory)
        {
            client = factory.CreateDefaultClient();
        }

        [Fact]
        public async void AddCategory()
        {
            //Arrange
            var category = new Category()
            {
                CategoryId = 1,
                CategoryName = "Test1",
                CategoryDescription = "this is just a test"
            };
            //Act 
            await client.PostAsJsonAsync("add/category", category);
            var getcategories = await client.GetFromJsonAsync<IEnumerable<Category>>("categories");
            //Assert
            getcategories.Should().NotBeNull();

        }
    }
}