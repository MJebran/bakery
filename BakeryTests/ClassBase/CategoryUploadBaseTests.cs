using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bakery.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using BakeryTests.ServicesTests;
using Bakery.WebApp.Telemetry;
using OpenTelemetry.Trace;
using Moq;
using Bakery.WebApp.Services;
using Microsoft.AspNetCore.Components.Forms;
using AngleSharp.Text;

namespace BakeryTests.ClassBase;

public class CategoryUploadBaseTests: TestContext
{
    [Fact]
    public async Task AddCategoryTest()
    {
        //Arrange
        Category category = new Category();
        {
            category.CategoryId = 1;
            category.CategoryName = "Test";
            category.CategoryDescription = "Test";
        };
        
        Mock<ICategoryService> mockCategoryService = new();

        //Act
        mockCategoryService.Setup(x => x.AddCategory(category)).Returns(Task.FromResult(category));
        await Task.Delay(1);
        var categoryName = mockCategoryService.Object.AddCategory(category);
        mockCategoryService.Verify(x => x.AddCategory(category));
        
        //Assert
        Assert.NotNull(category);
    }

    [Fact]
    public async Task AddCategoryTest2()
    {
        //Arrange
        Category category = new Category();
        {
            category.CategoryId = 1;
            category.CategoryName = "Cake";
            category.CategoryDescription = "Test";
        };
        
        Mock<ICategoryService> mockCategoryService = new();

        //Act
        mockCategoryService.Setup(x => x.AddCategory(category)).Returns(Task.FromResult(category));
        await Task.Delay(1);
        var categoryName = mockCategoryService.Object.AddCategory(category);
        mockCategoryService.Verify(x => x.AddCategory(category));
        
        //Assert
        Assert.Equal("Cake", category.CategoryName);
    }

    [Fact]
    public async Task AddCategoryTest3()
    {
        //Arrange
        Category category = new Category();
        {
            category.CategoryId = 1;
            category.CategoryName = null;
            category.CategoryDescription = "Test";
        };
        
        Mock<ICategoryService> mockCategoryService = new();

        //Act
        mockCategoryService.Setup(x => x.AddCategory(category)).Returns(Task.FromResult(category));
        await Task.Delay(1);
        var categoryName = mockCategoryService.Object.AddCategory(category);
        mockCategoryService.Verify(x => x.AddCategory(category));
        
        //Assert
        Assert.Null(category.CategoryName);
    }

    [Fact]
    public async Task AddCategoryTest4()
    {
        //Arrange
        Category category = new Category();
        {
            category.CategoryId = 1;
            category.CategoryName = "Cake";
            category.CategoryDescription = null;
        };
        
        Mock<ICategoryService> mockCategoryService = new();

        //Act
        mockCategoryService.Setup(x => x.AddCategory(category)).Returns(Task.FromResult(category));
        await Task.Delay(1);
        var categoryName = mockCategoryService.Object.AddCategory(category);
        mockCategoryService.Verify(x => x.AddCategory(category));
        
        //Assert
        Assert.Null(category.CategoryDescription);
    }
}


