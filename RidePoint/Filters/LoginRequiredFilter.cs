﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RidePoint.Filters
{
    public class LoginRequiredFilter : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginRequiredFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isLoggedIn = _httpContextAccessor.HttpContext?.Session.GetInt32("UserId") != null;

            if (!isLoggedIn)
            {
                context.Result = new RedirectToActionResult("Login", "Authenticate", null);
            }
        }
    }
}