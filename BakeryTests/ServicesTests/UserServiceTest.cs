using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;

public class UserServiceTest : IUserService
{
    List<User> users {get; set;}
    public UserServiceTest()
    {
        users = new();   
    }
    public async Task AddUser(User user)
    {
        users.Add(user);
        await Task.CompletedTask;
    }

    public async Task DeleteUser(int id)
    {
        var itemToRemove = users.Where(u => u.UserId == id).FirstOrDefault();
        users.Remove(itemToRemove ?? throw new Exception("item not found"));
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        await Task.CompletedTask;
        return users;
    }

    public Task UpdateUser(int id)
    {
        throw new NotImplementedException();
    }
}