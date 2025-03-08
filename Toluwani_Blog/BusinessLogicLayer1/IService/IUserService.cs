using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface IUserService
    {
        User? CreateUser(User user, out string message);

        User? GetUserByRole(string role, out string message);

        bool DeleteUser(int id, out string message);

        List<User> GetAllUsers();

        User? GetUser(int id);

        User? UpdateUser(User user, out string message);
    }
}
