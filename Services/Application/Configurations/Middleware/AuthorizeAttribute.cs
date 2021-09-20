using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Configurations.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public ICollection<string> Roles { get; set; }

        public AuthorizeAttribute(params string[] roles)
        {
            Roles = roles.Select(x => x.ToLower()).ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var user = (User)context.HttpContext.Items["User"];
            //if (user == null)
            //{
            //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //}
            //else
            //{
            //    if (user.StatusNavigation.Name == "Banned")
            //    {
            //        context.Result = new JsonResult(new { message = "Your account has been banned" }) { StatusCode = StatusCodes.Status403Forbidden };
            //    }
            //    var userRoles = user.UserRoles.Select(x => x.Role.Name).ToList();
            //    var isValid = false;
            //    userRoles.ForEach(role =>
            //    {
            //        if (Roles.Contains(role.ToLower()))
            //        {
            //            isValid = true;
            //        }
            //    });
            //    if (!isValid)
            //    {
            //        context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
            //    }
            //}
        }
    }
}
