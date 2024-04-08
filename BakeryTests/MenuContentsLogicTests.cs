using Bakery.WebApp.Data;
using FluentAssertions;
using Bakery.WebApp.Logic;

namespace BakeryTests
{

    public class MenuContentsLogicTets 
    {
        ItemTypeServiceTest itemProvider = new();
        CategoryServiceTest categoryProvider = new();
        SizeServiceTest sizeProvider = new();
        MenuContentsLogic _logicObject;

        [Fact]
        public async void EmptyFilterWorks()
        {
            //Arrange
            _logicObject = new(itemProvider, categoryProvider, sizeProvider);

            string filter = "";
            
            //Act 
            _logicObject.FilterSelection(filter);

            //Assert
            _logicObject.filterItems.Should().BeEmpty();
        }

        [Fact]
        public async void NotMatchingFilterWorks()
        {
            //Arrange
            var item1 = new Itemtype(){ItemName = "testCake", Category = new Category(){CategoryName = "cake"}};
            await itemProvider.AddItemtype(item1);

            _logicObject = new(itemProvider, categoryProvider, sizeProvider);

            string filter = "notCake";
            
            //Act 
            _logicObject.FilterSelection(filter);

            //Assert
            _logicObject.filterItems.Should().BeEmpty();
        }

        [Fact]
        public async void MatchingFilterWorks()
        {
            //Arrange
            var item1 = new Itemtype(){ItemName = "testCake", Category = new Category(){CategoryName = "cake"}};
            await itemProvider.AddItemtype(item1);
           
            _logicObject = new(itemProvider, categoryProvider, sizeProvider);

            string filter = "cake";
            
            //Act 
            _logicObject.FilterSelection(filter);

            //Assert
            _logicObject.filterItems.Should().NotBeEmpty();
        }

        [Fact]
        public async void MatchingFilterWorksWithMultipleObjects()
        {
            //Arrange
            var item1 = new Itemtype(){ItemName = "testCake", Category = new Category(){CategoryName = "cake"}};
            var item2 = new Itemtype(){ItemName = "testBread", Category = new Category(){CategoryName = "bread"}};

            await itemProvider.AddItemtype(item1);
            await itemProvider.AddItemtype(item2);

            _logicObject = new(itemProvider, categoryProvider, sizeProvider);

            string filter = "cake";
            
            //Act 
            _logicObject.FilterSelection(filter);

            //Assert
            _logicObject.filterItems.Should().HaveCount(1);
        }

        [Fact]
        public async void MatchingFilterWorksWithMultipleObjectsOfTheSameType()
        {
            //Arrange
            var item1 = new Itemtype(){ItemName = "testCake", Category = new Category(){CategoryName = "cake"}};
            var item2 = new Itemtype(){ItemName = "testBread", Category = new Category(){CategoryName = "bread"}};
            var item3 = new Itemtype(){ItemName = "testBread2", Category = new Category(){CategoryName = "bread"}};

            await itemProvider.AddItemtype(item1);
            await itemProvider.AddItemtype(item2);
            await itemProvider.AddItemtype(item3);

            _logicObject = new(itemProvider, categoryProvider, sizeProvider); 

            string filter = "cake";
            
            //Act 
            _logicObject.FilterSelection(filter);

            //Assert
            _logicObject.filterItems.Should().HaveCount(1);
        }
    }

}