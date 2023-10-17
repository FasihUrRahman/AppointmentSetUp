using Appoinment.Models;
using Appoinment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user; //Get Values From Repostory Libery
        public UserController(IUser user) //This Constructor will give all the methods to _user from IUser
        {
            _user = user;
        }
        [Admin]
        [HttpGet]
        public IActionResult Roles()
        {
            return View(_user.GetRoles());
        }
        [HttpGet]
        public IActionResult AddEditRole(int id = 0)
        {
            return View(_user.GetRole(id));
        }
        [HttpPost]
        public IActionResult AddEditRole(UserRole userRole)
        {
            _user.AddEditRole(userRole);
            return RedirectToAction("Roles");
        }
        [HttpGet]
        public IActionResult DeleteRole(int id)
        {
            _user.DeleteRole(id);
            return RedirectToAction("Roles");
        }
        /*--------------Users--------------*/
        [Admin]
        [HttpGet]
        public IActionResult Users()
        {
            return View(_user.GetUsers());
        }
        [HttpGet]
        public IActionResult AddEditUser(int id = 0)
        {
            //ViewBag is Help To Save Data Here It Getting Roles From DB
            ViewBag.AllRoles = new SelectList(_user.GetRoles().ToList(), "Id", "Name");
            return View(_user.GetUser(id));
        }
        [HttpPost]
        public IActionResult AddEditUser(User user)
        {
            _user.AddEditUser(user);
            return RedirectToAction("Users");
        }
        //DeleteUser
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            _user.DeleteUser(id);
            return RedirectToAction("Users");
        }
    }
}
