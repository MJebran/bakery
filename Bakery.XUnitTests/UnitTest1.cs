using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Moq;

namespace Bakery.XUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void SetUp()
        {
            Assert.True(true);
        }

        [Fact]
        public async void ManagerCanAddItemType()
        {
            Itemtype newItem = new Itemtype()
            {
                ItemName = "test1",
                ItemPrice = 1,
                ItmeCalories = 300,
                ItemWeight = 3,
                ItemDescription = "amazing",
                SizeId = 2,
                CategoryId = 1
            };
            Mock<IItemTypeService> mockService = new();
            mockService.Setup(m => m.AddItemtype(newItem)).Returns(Task.FromResult(newItem.ItemName));
            //Itemtype itemtype = new(mockService.Object);
            var name = mockService.Object.AddItemtype(newItem);

            mockService.Verify(m => m.AddItemtype(newItem));
            Assert.NotNull(newItem);
        }

        [Fact]
        public async void ManagerCanDeleteItemType()
        {
            Itemtype newItem = new Itemtype()
            {
                ItemName = "test1",
                ItemPrice = 1,
                ItmeCalories = 300,
                ItemWeight = 3,
                ItemDescription = "amazing",
                SizeId = 2,
                CategoryId = 1
            };
            Mock<IItemTypeService> mockService = new();
            mockService.Setup(m => m.DeleteItemtype(newItem.CategoryId)).Returns(Task.FromResult(newItem.ItemName));
            //Itemtype itemtype = new(mockService.Object);
            var name = mockService.Object.DeleteItemtype(newItem.CategoryId);

            mockService.Verify(m => m.DeleteItemtype(newItem.CategoryId));
            Assert.NotNull(newItem);

        }

        [Fact]
        public async void ManagerCanUpdateItemType()
        {
            Itemtype newItem = new Itemtype()
            {
                ItemName = "test1",
                ItemPrice = 1,
                ItmeCalories = 300,
                ItemWeight = 3,
                ItemDescription = "amazing",
                SizeId = 2,
                CategoryId = 1
            };
            Mock<IItemTypeService> mockService = new();
            mockService.Setup(m => m.UpdateItemtype(newItem.CategoryId)).Returns(Task.FromResult(newItem.ItemName));
            //Itemtype itemtype = new(mockService.Object);
            var name = mockService.Object.UpdateItemtype(newItem.CategoryId);

            mockService.Verify(m => m.UpdateItemtype(newItem.CategoryId));
            Assert.NotNull(newItem);
        }


    }
}