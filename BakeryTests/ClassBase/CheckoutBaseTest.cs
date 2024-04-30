using Bakery.ClassLibrary.Logic;
using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Authentication;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bunit;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;

public class CheckoutBaseTest : TestContext
{
    //[Fact]
    //public async Task MarkCartAsCompletedPurchase_MarksCartAsCompleted()
    //{
    //    var emailService = new EmailServiceTest();
    //    Services.AddSingleton<IEmailService>(emailService);
    //    Services.AddSingleton<IBakeryAutheticationService, BakeryAutheticationServiceTest>();
    //    Services.AddSingleton<IUserService, UserServiceTest>();
    //    Services.AddSingleton<IRoleService, RoleServiceTest>();
    //    Services.AddSingleton<IPurchaseService, PurchaseServiceTest>();

    //    var user = new User { UserEmail = "example@example.com" };
    //    var userCart = new Purchase { PurchaseId = 1, Ispayed = false };
    //    var itempurchases = new List<Itempurchase>();
    //    userCart.Itempurchases = itempurchases;

    //    var cut = RenderComponent<CheckoutBase>();

    //    // Act
    //    await cut.InvokeAsync(() => cut.Instance.MarkCartAsCompletedPurchase());

    //    // Assert
    //    Assert.True(userCart.Ispayed);
    //}
}