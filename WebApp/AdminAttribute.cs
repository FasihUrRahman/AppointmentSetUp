using Appointment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp
{
    public class AdminAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Get Cookies From User With Our Desired Name
            string accessToken = context.HttpContext.Request.Cookies["user-access-token"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                //To Get Required Data from Database and save it in db Variable
                AppointmentContext db = context.HttpContext.RequestServices.GetRequiredService<AppointmentContext>();
                var result = db.Users.Where(x => x.AccessToken.Equals(accessToken) && x.UserRole.Name == "Admin").Any();
                if (!result)
                {
                    context.Result = new RedirectResult("/Home/Index");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login");
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
