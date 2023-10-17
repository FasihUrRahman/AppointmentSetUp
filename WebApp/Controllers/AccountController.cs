using Appoinment.Models;
using Appoinment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccount _account;
        public AccountController(IUserAccount account)
        {
            _account = account;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection data)
        {
            //Get Data Form Users
            string email = data["EmailAddress"];
            string password = data["Password"];
            var dbUser = _account.GetUserForLogin(email, password);
            if (dbUser != null)
            {
                if (dbUser.IsConfirmed == true)
                {
                    //Expire Session After 30 Days
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.UtcNow.AddDays(30);
                    Response.Cookies.Append("user-access-token", dbUser.AccessToken, options);
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Error = "You Are Not Verified Yet!";
                    return View();
                }
            }
            ViewBag.Error = "Wrong Email Or Password";
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            string confermationToken = _account.Register(user);
            //If Values are No Correct
            if (string.IsNullOrEmpty(confermationToken))
            {
                ViewBag.Error = "Error Occoured";
                return View();
            }
            //If Values Are Correct Then User Will Register and Login to Web App
            else
            {
                if (confermationToken == "Error")
                {
                    ViewBag.Error = "This Email or Phone Number is Already Registered";
                    return View();
                }
                if (user.IsConfirmed == true)
                {
                    //Expire Session After 30 Days
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.UtcNow.AddDays(30);
                    Response.Cookies.Append("user-access-token", user.AccessToken, options);
                    return Redirect("/Home/Index");
                }
                else
                {
                    return Redirect("/Account/Login");
                }
            }
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user-access-token");
            return Redirect("/Account/Login");
        }
    }
}
