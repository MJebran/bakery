using Bakery.WebApp.Data;

namespace Bakery.ClassLibrary.Services;

public interface IUserService
{
    public Task AddUser(User user);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task DeleteUser(int id);
    public Task UpdateUser(int id);
}
