using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using FluentAssertions;
using BakeryTests.ServiceTests;
using Bakery.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;

namespace BakeryTests
{

    public class MenuContentsLogicTests : TestContext
    {
        [Fact]
        public async void EmptyFilterWorks()
        {
            Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
            Services.AddSingleton<ICategoryService, CategoryServiceTest>();
            Services.AddSingleton<ISizeService, SizeServiceTest>();

            // Arrange
            var cut = RenderComponent<Bakery.ClassLibrary.Logic.MenuContentsBase>();

            // Act
            await cut.InvokeAsync(() => cut.Instance.FilterSelection());

            // Assert
            var filterItemsCount = cut.Instance.filterItems.Count();
            Assert.Equal(0, filterItemsCount);
        }

        [Fact]
        public async void CakeEmptyFilterWorks()
        {
            Services.AddSingleton<IItemTypeService, ItemTypeServiceTest>();
            Services.AddSingleton<ICategoryService, CategoryServiceTest>();
            Services.AddSingleton<ISizeService, SizeServiceTest>();

            // Arrange
            var cut = RenderComponent<Bakery.ClassLibrary.Logic.MenuContentsBase>();

            // Act
            await cut.InvokeAsync(() => cut.Instance.FilterSelection());

            // Assert
            var filterItemsCount = cut.Instance.filterItems.Count();
            Assert.Equal(0, filterItemsCount);
        }

    }

}