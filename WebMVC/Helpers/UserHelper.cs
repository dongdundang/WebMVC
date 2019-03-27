using DTO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Helpers
{
    public static class UserHelper
    {
        public static ApplicationUser GetCurrentUser()
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId<int>();
            var currentUser = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>().FindById(currentUserId);
            return currentUser;
        }
    }
}