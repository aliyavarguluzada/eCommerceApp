﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eCommerceApp.Filters
{
    public class MyAuth : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string Role;
        public MyAuth(string role)
        {
            Role = role;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            bool isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                context.Result = new UnauthorizedResult();
            }
            var roleClaim = context.HttpContext.User.Claims.Where(c => c.Type == "Role").FirstOrDefault();
            if (roleClaim is null)
            {
                context.Result = new UnauthorizedResult();

            }
            if (roleClaim.Value != Role)
            {
                context.Result = new UnauthorizedResult();

            }

        }
    }
}
