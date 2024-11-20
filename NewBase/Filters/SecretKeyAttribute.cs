﻿using NewBase.Core.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace NewBase.Filters
{
    public class SecretKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var secretKey = actionContext.HttpContext.Request.Headers["SecretKey"].ToString();

            if (secretKey != Keys.SecretKey)
            {
                actionContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "controller", "error" },
                    { "action", "forbidden" },
                    { "message", "invalid secret key" }
                });
            }
            base.OnActionExecuting(actionContext);
        }
    }
}