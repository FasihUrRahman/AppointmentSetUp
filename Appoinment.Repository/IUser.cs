using Appoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Repository
{
    public interface IUser
    {
        List<UserRole> GetRoles();
        UserRole GetRole(int id);
        void AddEditRole(UserRole userRole);
        void DeleteRole(int id);
        //To Get Users From DB
        //Users Mehtods
        List<User> GetUsers();
        User GetUser(int id);
        void AddEditUser(User user);
        void DeleteUser(int id);
    }
}
