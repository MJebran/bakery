using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IUserService
{
    public Task AddUser(User user);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task DeleteUser(int id);
    public Task UpdateUser(int id);
}
