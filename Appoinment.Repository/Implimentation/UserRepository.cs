using Appoinment.Models;
using Appointment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Repository.Implimentation
{
    public class UserRepository : IUser
    {
        private readonly AppointmentContext _db;
        public UserRepository(AppointmentContext db)
        {
            _db = db;
        }
        public void AddEditRole(UserRole userRole)
        {
            _db.UsersRole.Update(userRole);
            _db.SaveChanges();
        }

        public void AddEditUser(User user)
        {
            if (!string.IsNullOrEmpty(user.AccessToken))
            {
                _db.Users.Update(user);
            }
            else
            {
                user.JoinedOn = DateTime.UtcNow.AddHours(5);
                user.AccessToken = Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks;
                _db.Users.Update(user);
            }
            _db.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            UserRole userRoleId = _db.UsersRole.Where(x => x.Id.Equals(id)).FirstOrDefault();
            _db.Remove(userRoleId);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User userId = _db.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();
            _db.Remove(userId);
            _db.SaveChanges();
        }

        public UserRole GetRole(int id)
        {
            return _db.UsersRole.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<UserRole> GetRoles()
        {
            return _db.UsersRole.ToList();
        }

        public User GetUser(int id)
        {
            return _db.Users.Where(x => x.Id == id).Include(x => x.UserRole).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _db.Users.Include(x => x.UserRole).ToList();
        }
    }
}
