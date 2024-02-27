using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IRoleService
{
    //public Task AddRole(Role size);
    public Task<IEnumerable<Role>> GetAllRoles();
}
