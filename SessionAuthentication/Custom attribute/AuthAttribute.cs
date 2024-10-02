using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SessionAuthentication.Custom_attribute
{
    public class AuthAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userName = context.HttpContext.Session.GetString("UserName");
            if(string.IsNullOrEmpty(userName) )
            {
                context.Result = new RedirectToActionResult("Login", "Home",null);
            }
            //base.OnActionExecuting(context);
        }
    }
}
