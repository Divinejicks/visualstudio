using SMS.Repository.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repository.Contract.Common
{
    public interface IUserRepository
    {
        IList<User> GetAllUsers();
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(User user);
        User GetUser(string code);
    }
}
