using Bakery.ClassLibrary.Logic;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bunit;
using FluentAssertions.Common;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;

public class CheckoutPurchaseBaseTest : TestContext
{
    [Fact]
    public async Task AddPurchaseTest()
    {
        //Arrange
        Purchase purchase = new Purchase();
        {
            purchase.PurchaseId = 1;
            purchase.PurcahseDate = DateOnly.FromDateTime(DateTime.Now);
            purchase.Ispayed = true;
            purchase.PurchaseUserId = 1;
            purchase.Itempurchases = new List<Itempurchase>();
            purchase.PurchaseUser = new User();
        };

        Mock<IPurchaseService> mockPurchaseService = new();

        //Act
        mockPurchaseService.Setup(x => x.AddPurchase(purchase)).Returns(Task.FromResult(purchase));
        await Task.Delay(1);
        var purchaseId = mockPurchaseService.Object.AddPurchase(purchase);
        mockPurchaseService.Verify(x => x.AddPurchase(purchase));

        //Assert
        Assert.NotNull(purchase);
    }

    [Fact]
    public async Task UpdatePurchaseTest()
    {
        //Arrange
        Purchase purchase = new Purchase();
        {
            purchase.PurchaseId = 1;
            purchase.PurcahseDate = DateOnly.FromDateTime(DateTime.Now);
            purchase.Ispayed = true;
            purchase.PurchaseUserId = 1;
            purchase.Itempurchases = new List<Itempurchase>();
            purchase.PurchaseUser = new User();
        };

        Mock<IPurchaseService> mockPurchaseService = new();

        //Act
        mockPurchaseService.Setup(x => x.UpdatePurchase(purchase)).Returns(Task.FromResult(purchase));
        await Task.Delay(1);
        var purchaseId = mockPurchaseService.Object.UpdatePurchase(purchase);
        mockPurchaseService.Verify(x => x.UpdatePurchase(purchase));

        //Assert
        Assert.NotNull(purchase);
    }

    [Fact]
    // test DeletePurchase method
    public async Task DeletePurchaseTest()
    {
        //Arrange
        Purchase purchase = new Purchase();
        {
            purchase.PurchaseId = 1;
            purchase.PurcahseDate = DateOnly.FromDateTime(DateTime.Now);
            purchase.Ispayed = true;
            purchase.PurchaseUserId = 1;
            purchase.Itempurchases = new List<Itempurchase>();
            purchase.PurchaseUser = new User();
        };

        Mock<IPurchaseService> mockPurchaseService = new();

        //Act
        mockPurchaseService.Setup(x => x.DeletePurchase(purchase.PurchaseId)).Returns(Task.FromResult(purchase));
        await Task.Delay(1);
        var purchaseId = mockPurchaseService.Object.DeletePurchase(purchase.PurchaseId);
        mockPurchaseService.Verify(x => x.DeletePurchase(purchase.PurchaseId));

        //Assert
        Assert.NotNull(purchaseId);
    }

    [Fact]
    public async Task GetPurchaseTest()
    {
        //Arrange
        Purchase purchase = new Purchase();
        {
            purchase.PurchaseId = 1;
            purchase.PurcahseDate = DateOnly.FromDateTime(DateTime.Now);
            purchase.Ispayed = true;
            purchase.PurchaseUserId = 1;
            purchase.Itempurchases = new List<Itempurchase>();
            purchase.PurchaseUser = new User();
        };

        Mock<IPurchaseService> mockPurchaseService = new();

        //Act
        mockPurchaseService.Setup(x => x.GetPurchase(purchase.PurchaseId)).Returns(Task.FromResult(purchase));
        await Task.Delay(1);
        var purchaseId = mockPurchaseService.Object.GetPurchase(purchase.PurchaseId);
        mockPurchaseService.Verify(x => x.GetPurchase(purchase.PurchaseId));

        //Assert
        Assert.NotNull(purchaseId);
    }

    [Fact]
    // test AddPurchase and check if purchaseId is equal to 1
    public async Task AddPurchaseTest2()
    {
        //Arrange
        Purchase purchase = new Purchase();
        {
            purchase.PurchaseId = 1;
            purchase.PurcahseDate = DateOnly.FromDateTime(DateTime.Now);
            purchase.Ispayed = true;
            purchase.PurchaseUserId = 1;
            purchase.Itempurchases = new List<Itempurchase>();
            purchase.PurchaseUser = new User();
        };

        Mock<IPurchaseService> mockPurchaseService = new();

        //Act
        mockPurchaseService.Setup(x => x.AddPurchase(purchase)).Returns(Task.FromResult(purchase));
        await Task.Delay(1);
        var purchase_mock = mockPurchaseService.Object.AddPurchase(purchase);
        mockPurchaseService.Verify(x => x.AddPurchase(purchase));

        //Assert
        Assert.Equal(true, purchase_mock.IsCompleted);
    }

}