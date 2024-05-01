using Bakery.ClassLibrary.Logic;
using Bakery.WebApp.Data;
using BakeryTests.ServiceTests;
using Bakery.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using FluentAssertions;
using Bakery.WebApp.Telemetry;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Components;

namespace BakeryTests;

public class ViewUserBaseTest : TestContext
{
    [Fact]
    public async void CanDeleteUser()
    {
        Services.AddSingleton<IUserService, UserServiceTest>();

        // Arrange
        var cut = RenderComponent<ViewUserBase>();

        // Act
        var testUser = new User{UserId=1, UserName="Carlos"};
        var UserService = Services.GetRequiredService<IUserService>();
        await UserService.AddUser(testUser);

        await cut.InvokeAsync(() => cut.Instance.DeleteUser(testUser));

        // Assert
        var users = await UserService.GetAllUsers();

        users.Should().BeEmpty();
    }

    [Fact]
public async void CanAddAndDeleteTwoUsers()
{
    Services.AddSingleton<IUserService, UserServiceTest>();

    // Arrange
    var cut = RenderComponent<ViewUserBase>();

    // Act
    var UserService = Services.GetRequiredService<IUserService>();
    var user1 = new User { UserId = 1, UserName = "User 1" };
    var user2 = new User { UserId = 2, UserName = "User 2" };
    await UserService.AddUser(user1);
    await UserService.AddUser(user2);

    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user1));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user2));

    // Assert
    var users = await UserService.GetAllUsers();

    users.Should().BeEmpty();
}

[Fact]
public async void CanAddAndDeleteThreeUsers()
{
    Services.AddSingleton<IUserService, UserServiceTest>();

    // Arrange
    var cut = RenderComponent<ViewUserBase>();

    // Act
    var UserService = Services.GetRequiredService<IUserService>();
    var user1 = new User { UserId = 1, UserName = "User 1" };
    var user2 = new User { UserId = 2, UserName = "User 2" };
    var user3 = new User { UserId = 3, UserName = "User 3" };
    await UserService.AddUser(user1);
    await UserService.AddUser(user2);
    await UserService.AddUser(user3);

    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user1));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user2));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user3));

    // Assert
    var users = await UserService.GetAllUsers();

    users.Should().BeEmpty();
}

[Fact]
public async void CanAddAndDeleteFourUsers()
{
    Services.AddSingleton<IUserService, UserServiceTest>();

    // Arrange
    var cut = RenderComponent<ViewUserBase>();

    // Act
    var UserService = Services.GetRequiredService<IUserService>();
    var user1 = new User { UserId = 1, UserName = "User 1" };
    var user2 = new User { UserId = 2, UserName = "User 2" };
    var user3 = new User { UserId = 3, UserName = "User 3" };
    var user4 = new User { UserId = 4, UserName = "User 4" };
    await UserService.AddUser(user1);
    await UserService.AddUser(user2);
    await UserService.AddUser(user3);
    await UserService.AddUser(user4);

    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user1));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user2));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user3));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user4));

    // Assert
    var users = await UserService.GetAllUsers();

    users.Should().BeEmpty();
}

[Fact]
public async void CanAddAndDeleteFiveUsers()
{
    Services.AddSingleton<IUserService, UserServiceTest>();

    // Arrange
    var cut = RenderComponent<ViewUserBase>();

    // Act
    var UserService = Services.GetRequiredService<IUserService>();
    var user1 = new User { UserId = 1, UserName = "User 1" };
    var user2 = new User { UserId = 2, UserName = "User 2" };
    var user3 = new User { UserId = 3, UserName = "User 3" };
    var user4 = new User { UserId = 4, UserName = "User 4" };
    var user5 = new User { UserId = 5, UserName = "User 5" };
    await UserService.AddUser(user1);
    await UserService.AddUser(user2);
    await UserService.AddUser(user3);
    await UserService.AddUser(user4);
    await UserService.AddUser(user5);

    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user1));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user2));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user3));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user4));
    await cut.InvokeAsync(() => cut.Instance.DeleteUser(user5));

    // Assert
    var users = await UserService.GetAllUsers();

    users.Should().BeEmpty();
}

    
}